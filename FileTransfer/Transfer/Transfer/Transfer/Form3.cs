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
    public partial class WaitingPage : Form
    {
        /* 대용량 파일 전송 간, 전송 중임을 알리는 페이지 */
        public WaitingPage()
        {
            InitializeComponent();
            /* 화면 정 중앙에 페이지가 뜨도록 작업 */
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

