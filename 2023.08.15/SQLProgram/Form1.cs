using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLProgram.Model;

namespace SQLProgram
{
    public partial class Form1 : Form
    {
        List<Model.DBinfo> dbList;
        SqlConnection connection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void SetMenu()
        {
            if(comboBox.SelectedText == "Ms - SQL")
            {
                dbList = new List<Model.DBinfo>();
                string ipInfo = ipInfoBox.Text;
                int portInfo = Convert.ToInt32(portInfoBox.Text);
                string dbNameInfo = dbNameinfoBox.Text;
                string userNameInfo = userNameInfoBox.Text;
                string passwordInfo = pwInfoBox.Text;

                string connectStr = string.Format("DataFormat={0},{1};InitialCatalog={2};UserID={3};Password={4}",
                                                  ipInfo, portInfo, dbNameInfo, userNameInfo, passwordInfo);
                SqlConnection connection = new SqlConnection(connectStr);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void clickConnectBtn(object sender, EventArgs e)
        {
            SetMenu();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMenu();
        }
    }
}
