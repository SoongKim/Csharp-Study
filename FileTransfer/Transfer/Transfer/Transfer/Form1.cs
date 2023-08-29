using System.Net.Http;
/* 프로그램 측 코드 */
namespace Transfer
{
    public partial class Form1 : Form
    {
        #region >> 기초 세팅
        public Form1()
        {
            InitializeComponent();
            /* 화면 정 중앙에 페이지가 뜨도록 작업 */
            StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region >> 전역 변수 영역
        /* Form2를 통해 사용자로부터 입력 받는 Url과 포트 정보. 디폴트 값으로 localhost, 7251이 기입되어 있습니다.*/
        internal string targetUrlPath;
        internal string targetPortNumber;
        /* 전송 대상 파일의 경로 정보*/
        internal string SelectedFilePath;
        #endregion

        #region >> 파일 선택 영역
        private void FileBtnClick(object sender, EventArgs e)
        {
            /* OpenFileDialog : 파일 탐색기를 열어, 사용자가 선택한 파일의 정보 확보를 지원한다. */
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                /* 기본 필터로 모든 파일을 선택 */
                ofd.Title = "파일 선택";
                ofd.Filter = "모든 파일(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    /* OK(확인) 버튼을 클릭했다면 선택한 파일의 경로 정보를 변수에 저장하고,
                       TextBox에 해당 경로 정보를 출력한다. */
                    SelectedFilePath = ofd.FileName;
                    FileNameBox.Text = ofd.FileName;
                }
                else
                {
                    /* 취소 버튼을 눌렀다면, TextBox를 비운다. */
                    FileNameBox.Text = null;
                }
            }
        }
        #endregion

        #region >> 전송 버튼 클릭 시
        private async void TransferClick(object sender, EventArgs e)
        {
            /* Url 경로가 비어있거나, 값이 존재하지 않는다면 아래 문구를 출력한다.*/
            if (string.IsNullOrEmpty(targetUrlPath) || string.IsNullOrEmpty(SelectedFilePath))
            {
                MessageBox.Show("URL과 파일을 입력하세요.");
                return;
            }

            /* Url 정보와 파일 경로 정보를 각각 변수에 저장하고, UploadingFile 메서드 운용 간 활용한다. */
            var serverUrl = $"{targetUrlPath}:{targetPortNumber}/api/FileUpload";
            var localFilePath = SelectedFilePath;
            await UploadingFile(serverUrl, localFilePath);
        }
        #endregion

        #region >> 청크 단위 업로드 파트
        private async Task UploadingFile(string serverUrl, string localFilePath)
        {
            /* HttpClient와 File 클래스들을 사용한다.
             * HttpClient() : 네트워크 관련 요청을 생성하고, 수행하는 클래스. 서버 연결을 위해 필요하다.
             * File.OpenRead() : 경로로부터 파일을 읽는 데 활용한다. 
             */
            using (var client = new HttpClient())
            using (var fileStream = File.OpenRead(localFilePath))
            {
                /* 기본 Chunk 크기로 5MB를 지정(1MB = 1024KB = 1024*1024 Bytes 이므로) */
                const int chunkSize = 5 * 1024 * 1024;
                var buffer = new byte[chunkSize];
                int bytesRead;

                string fileName = Path.GetFileName(localFilePath);
                long totalBytesRead = 0;

                MessageBox.Show("파일을 전송 중입니다.");
                /* MessageBox를 열어 문구를 출력하고, 전송이 완료될 때까지 Form3를 화면에 출력한다. */
                WaitingPage wp = new WaitingPage();
                wp.Show();
                
                /* 읽어들인 바이트 수가 총 파일 크기에 다다를 때까지 반복한다. */
                while ((bytesRead = fileStream.Read(buffer, 0, chunkSize)) > 0)
                {
                    /* using () 방식을 사용하면 필요 시점에만 메모리를 사용하고, 기능 종료 시 자동으로 자원을 회수한다.
                     * 선언 후 Close()하는 방식과 약간의 차이를 지닌다. */
                    using (var content = new MultipartFormDataContent())
                    {
                        content.Add(new ByteArrayContent(buffer, 0, bytesRead), "file", fileName);

                        /* 청크 정보 전달 간 시작과 끝 Byte에 관한 정보를 추가한다. -- 재조합 시 활용 */
                        client.DefaultRequestHeaders.Add("startByte", totalBytesRead.ToString());
                        client.DefaultRequestHeaders.Add("endByte", (totalBytesRead + bytesRead - 1).ToString());

                        /* 해당 IP, 포트의 주소로 Post 타입 request를 전송하고, 올바르게 요청이 이뤄졌는지 확인한다. */
                        var response = await client.PostAsync($"https://{serverUrl}", content);
                        response.EnsureSuccessStatusCode();

                        /* 요청 헤더 부분에서 청크 관련 정보를 제거한다. */
                        client.DefaultRequestHeaders.Remove("startByte");
                        client.DefaultRequestHeaders.Remove("endByte");

                        /* 일순을 마치고 읽어들인 총 바이트 수를 갱신한다. */
                        totalBytesRead += bytesRead;
                    }
                }
                /* 전송 완료 시점. Form3를 닫고 MessageBox를 출력 */
                wp.Close();
                MessageBox.Show("전송이 완료되었습니다!");
            }
        }
        #endregion

        #region >> 주소 정보 입력 (to Form2)
        private async void UrlBtnClick(object sender, EventArgs e)
        {
            using (var urlForm = new UrlForm())
            {
                /* urlForm : Form2. 주소창 입력 페이지 
                   해당 Form의 전역 변수 저장 값들을 받아와 현 Form 전역 변수에 저장 */
                urlForm.ShowDialog();
                targetUrlPath = urlForm.targetUrl;
                targetPortNumber = urlForm.targetPort;
                /* 작업을 마친 페이지는 닫는다. */
                urlForm.Close();
            }
        }
        #endregion
    }
}