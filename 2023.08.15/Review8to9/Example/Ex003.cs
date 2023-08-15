using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review8to9.Example
{
    //Ex003 : 디렉토리 확인 및 생성, 로그 파일 생성,
    //        DB 연결 구축 및 종료 시점을 로그 파일에 기록
    internal class Ex003
    {
        private readonly string logFileDir = Environment.CurrentDirectory;
        private readonly string connectionStr =
            string.Format("Data Source = {0},{1};" +
                          "Initial Catalog = {2};" +
                          "User ID = {3}; Password = {4}", 
                          "", , "", "", "");
        public void Run()
        {
            CheckDirectory();
            TryConnectDatabase();
            Console.ReadKey();
        }
        private void CheckDirectory()
        {
            Console.WriteLine("로그 파일 디렉토리를 확인합니다.");
            DirectoryInfo dirInfo = new DirectoryInfo(logFileDir+@"\data");
            if(!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("로그 디렉토리를 생성하였습니다.");
                Console.WriteLine("디렉토리 경로 : {0}", dirInfo.FullName);
            }
            else
            {
                Console.WriteLine("디렉토리 경로 : {0}", dirInfo.FullName);
            }
            Console.WriteLine();
        }

        private void TryConnectDatabase()
        {
            Console.WriteLine("=========================");
            SqlConnection connection = new SqlConnection(connectionStr);

            string FileName = string.Format(@"\data\db{0}.log",
                                            DateTime.Now.ToString("yyyyMMddHHmmss"));

            StreamWriter sw = new StreamWriter(logFileDir+FileName, true);
            Console.WriteLine("로그파일 경로 : {0}",
                              logFileDir + FileName);
            Console.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
            sw.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
            try
            {
                connection.Open();
            }
            catch
            {
                Console.WriteLine("[{0}] 데이터베이스 연결 실패...", DateTime.Now);
                sw.WriteLine("[{0}] 데이터베이스 연결 실패...", DateTime.Now);
                return;
            }
            Console.WriteLine("[{0}] 데이터베이스 연결 성공...", DateTime.Now);
            sw.WriteLine("[{0}] 데이터베이스 연결 성공...", DateTime.Now);

            Console.WriteLine("[{0}] 데이터베이스 연결 종료 시도...", DateTime.Now);
            sw.WriteLine("[{0}] 데이터베이스 연결 종료 시도...", DateTime.Now);
            try
            {
                connection.Close();
            }
            catch
            {
                Console.WriteLine("[{0}] 데이터베이스 연결 종료 실패...", DateTime.Now);
                sw.WriteLine("[{0}] 데이터베이스 연결 종료 실패...", DateTime.Now);
            }
            Console.WriteLine("[{0}] 데이터베이스 연결 종료 성공...", DateTime.Now);
            sw.WriteLine("[{0}] 데이터베이스 연결 종료 성공...", DateTime.Now);
            sw.Close();
            Console.WriteLine("=========================");
        }
    }
}
