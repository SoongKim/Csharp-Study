using System.Net.Http;
/* ���α׷� �� �ڵ� */
namespace Transfer
{
    public partial class Form1 : Form
    {
        #region >> ���� ����
        public Form1()
        {
            InitializeComponent();
            /* ȭ�� �� �߾ӿ� �������� �ߵ��� �۾� */
            StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region >> ���� ���� ����
        /* Form2�� ���� ����ڷκ��� �Է� �޴� Url�� ��Ʈ ����. ����Ʈ ������ localhost, 7251�� ���ԵǾ� �ֽ��ϴ�.*/
        internal string targetUrlPath;
        internal string targetPortNumber;
        /* ���� ��� ������ ��� ����*/
        internal string SelectedFilePath;
        #endregion

        #region >> ���� ���� ����
        private void FileBtnClick(object sender, EventArgs e)
        {
            /* OpenFileDialog : ���� Ž���⸦ ����, ����ڰ� ������ ������ ���� Ȯ���� �����Ѵ�. */
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                /* �⺻ ���ͷ� ��� ������ ���� */
                ofd.Title = "���� ����";
                ofd.Filter = "��� ����(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    /* OK(Ȯ��) ��ư�� Ŭ���ߴٸ� ������ ������ ��� ������ ������ �����ϰ�,
                       TextBox�� �ش� ��� ������ ����Ѵ�. */
                    SelectedFilePath = ofd.FileName;
                    FileNameBox.Text = ofd.FileName;
                }
                else
                {
                    /* ��� ��ư�� �����ٸ�, TextBox�� ����. */
                    FileNameBox.Text = null;
                }
            }
        }
        #endregion

        #region >> ���� ��ư Ŭ�� ��
        private async void TransferClick(object sender, EventArgs e)
        {
            /* Url ��ΰ� ����ְų�, ���� �������� �ʴ´ٸ� �Ʒ� ������ ����Ѵ�.*/
            if (string.IsNullOrEmpty(targetUrlPath) || string.IsNullOrEmpty(SelectedFilePath))
            {
                MessageBox.Show("URL�� ������ �Է��ϼ���.");
                return;
            }

            /* Url ������ ���� ��� ������ ���� ������ �����ϰ�, UploadingFile �޼��� ��� �� Ȱ���Ѵ�. */
            var serverUrl = $"{targetUrlPath}:{targetPortNumber}/api/FileUpload";
            var localFilePath = SelectedFilePath;
            await UploadingFile(serverUrl, localFilePath);
        }
        #endregion

        #region >> ûũ ���� ���ε� ��Ʈ
        private async Task UploadingFile(string serverUrl, string localFilePath)
        {
            /* HttpClient�� File Ŭ�������� ����Ѵ�.
             * HttpClient() : ��Ʈ��ũ ���� ��û�� �����ϰ�, �����ϴ� Ŭ����. ���� ������ ���� �ʿ��ϴ�.
             * File.OpenRead() : ��ηκ��� ������ �д� �� Ȱ���Ѵ�. 
             */
            using (var client = new HttpClient())
            using (var fileStream = File.OpenRead(localFilePath))
            {
                /* �⺻ Chunk ũ��� 5MB�� ����(1MB = 1024KB = 1024*1024 Bytes �̹Ƿ�) */
                const int chunkSize = 5 * 1024 * 1024;
                var buffer = new byte[chunkSize];
                int bytesRead;

                string fileName = Path.GetFileName(localFilePath);
                long totalBytesRead = 0;

                MessageBox.Show("������ ���� ���Դϴ�.");
                /* MessageBox�� ���� ������ ����ϰ�, ������ �Ϸ�� ������ Form3�� ȭ�鿡 ����Ѵ�. */
                WaitingPage wp = new WaitingPage();
                wp.Show();
                
                /* �о���� ����Ʈ ���� �� ���� ũ�⿡ �ٴٸ� ������ �ݺ��Ѵ�. */
                while ((bytesRead = fileStream.Read(buffer, 0, chunkSize)) > 0)
                {
                    /* using () ����� ����ϸ� �ʿ� �������� �޸𸮸� ����ϰ�, ��� ���� �� �ڵ����� �ڿ��� ȸ���Ѵ�.
                     * ���� �� Close()�ϴ� ��İ� �ణ�� ���̸� ���Ѵ�. */
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new ByteArrayContent(buffer, 0, bytesRead), "file", fileName);

                        /* ûũ ���� ���� �� ���۰� �� Byte�� ���� ������ �߰��Ѵ�. -- ������ �� Ȱ�� */
                        client.DefaultRequestHeaders.Add("startByte", totalBytesRead.ToString());
                        client.DefaultRequestHeaders.Add("endByte", (totalBytesRead + bytesRead - 1).ToString());

                        /* �ش� IP, ��Ʈ�� �ּҷ� Post Ÿ�� request�� �����ϰ�, �ùٸ��� ��û�� �̷������� Ȯ���Ѵ�. */
                        var response = await client.PostAsync($"https://{serverUrl}", content);
                        response.EnsureSuccessStatusCode();

                        /* ��û ��� �κп��� ûũ ���� ������ �����Ѵ�. */
                        client.DefaultRequestHeaders.Remove("startByte");
                        client.DefaultRequestHeaders.Remove("endByte");

                        /* �ϼ��� ��ġ�� �о���� �� ����Ʈ ���� �����Ѵ�. */
                        totalBytesRead += bytesRead;
                    }
                }
                /* ���� �Ϸ� ����. Form3�� �ݰ� MessageBox�� ��� */
                wp.Close();
                MessageBox.Show("������ �Ϸ�Ǿ����ϴ�!");
            }
        }
        #endregion

        #region >> �ּ� ���� �Է� (to Form2)
        private async void UrlBtnClick(object sender, EventArgs e)
        {
            using (var urlForm = new UrlForm())
            {
                /* urlForm : Form2. �ּ�â �Է� ������ 
                   �ش� Form�� ���� ���� ���� ������ �޾ƿ� �� Form ���� ������ ���� */
                urlForm.ShowDialog();
                targetUrlPath = urlForm.targetUrl;
                targetPortNumber = urlForm.targetPort;
                /* �۾��� ��ģ �������� �ݴ´�. */
                urlForm.Close();
            }
        }
        #endregion
    }
}