using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transfer
{
    public partial class UrlForm : Form
    {
        #region >> 전역변수
        /* IP, Port 정보 */
        public string targetUrl;
        public string targetPort;
        #endregion
        public UrlForm()
        {
            InitializeComponent();
            /* 화면 정 중앙에 페이지가 뜨도록 작업 */
            StartPosition = FormStartPosition.CenterScreen;
        }

        #region >> Url 주소, 포트 세팅
        private void SetClick(object sender, EventArgs e)
        {
            /* 각각의 TextBox에 유저가 기입한 사항을 각 변수에 저장.
               이후 IP + : + Port 문자열을 targetAccess 변수에 저장*/
            targetUrl = UrlBox.Text;
            targetPort = PortBox.Text;
            string targetAccess = targetUrl + ":" + targetPort;
            MessageBox.Show(targetAccess + " 주소로 연결합니다.");
            this.Close();
        }
        #endregion
    }
}
