using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Review8to9.Service
{
    internal class Service01
    {
        private readonly string dirInfo = Environment.CurrentDirectory;
        private readonly string connectStr = string.Format(
            "Data Source={0},{1};Initial Catalog={2};" +
            "User ID={3};Password={4}",
            "", , "", "", "");
        public void Run()
        {
            SettingDir();
            TryConnectToDB();
        }
        private void SettingDir()
        {
            Console.WriteLine("로그 파일 대상 디렉토리를 탐색합니다.");
            DirectoryInfo logDirInfo = new DirectoryInfo(dirInfo + @"\data");
            if (!logDirInfo.Exists)
            {
                Console.WriteLine("디렉토리가 존재하지 않습니다. 신규 생성합니다.");
                logDirInfo.Create();
                Console.WriteLine("경로 : {0}", logDirInfo.FullName);
            }
            else
            {
                Console.WriteLine("경로 : {0}", logDirInfo.FullName);
            }
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine();
        }
        private void TryConnectToDB()
        {
            SqlConnection connection = new SqlConnection(connectStr);
            string fileInfo = string.Format(@"\data\log{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));

            StreamWriter sw = new StreamWriter(dirInfo + fileInfo, true);
            sw.WriteLine("[{0}] DB 연결을 시도합니다...", DateTime.Now);
            Console.WriteLine("[{0}] DB 연결을 시도합니다...", DateTime.Now);
            connection.Open();
            sw.WriteLine("[{0}] DB 연결이 성공하였습니다.", DateTime.Now);
            Console.Write("[{0}] DB 연결이 성공하였습니다.", DateTime.Now);

            Console.WriteLine("테이블 명을 입력해주세요.");
            string tableName = Console.ReadLine();
            sw.WriteLine("[[{0}] 테이블명 : {1}", DateTime.Now, tableName);

            string searchSql = string.Format("SELECT * From {0};", tableName);
            SqlCommand searchCommand = new SqlCommand(searchSql, connection);
            SqlDataReader searchReader = searchCommand.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(searchReader);

            foreach(DataRow row in dataTable.Rows)
            {
                foreach(DataColumn column in dataTable.Columns)
                {
                    Console.Write("/ {0} ", row[column]);
                    sw.Write("/ {0} ", row[column]);
                }
                Console.Write("/");
                sw.Write("/");
                Console.WriteLine();
                sw.WriteLine();
            }
            sw.Close();
            connection.Close();

        }
    }
}
