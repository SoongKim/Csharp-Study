using Chapter08.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08.Service
{
    // SQL Connection 및 INSERT QUERY 기본
    public class Service01
    {
        // 현재 작업 디렉토리 위치 정보 확보
        private readonly string currentDirectory =
            Environment.CurrentDirectory;
        // DB Connection 구축 정보
        private readonly string connectionStr =
            string.Format("Data Source={0},{1};" +
                          "Initial Catalog={2};" +
                          "User ID={3};" +
                          "Password={4}",
                          "127.0.0.1", 1433, "testdb2", "sa", "kj920412");
        public void Run()
        {
            CheckDirectory();
            TryConnectToDatabase();
        }
        private void CheckDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory + @"\data");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("디렉토리를 생성하였습니다.");
                Console.WriteLine("생성경로 : {0}", dirInfo.FullName);
            }
            else
            {
                Console.WriteLine("대상경로 : {0}", dirInfo.FullName);
            }
        }
        private void TryConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            string fileName = string.Format(@"\data\db{0}.log",
                DateTime.Now.ToString("yyyyMMdd"));

            using (StreamWriter sw = new StreamWriter(currentDirectory + fileName, true))
            {
                sw.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
                connection.Open();
                sw.WriteLine("[{0}] 데이터베이스 연결 성공", DateTime.Now);
                Model.User user = SetUser();
                string insertQuery = string.Format("INSERT INTO TB_USER (ID, NAME, AGE, JOB) VALUES ('{0}', '{1}', {2}, '{3}')",
                    user.ID, user.Name, user.Age, user.Job);
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    int activeNumber = command.ExecuteNonQuery();
                    sw.WriteLine("영향 받은 데이터 : " + activeNumber);
                }
                sw.WriteLine("[{0}] 데이터베이스 연결 종료...", DateTime.Now);
                connection.Close();
                sw.WriteLine("[{0}] 데이터베이스 연결 종료 OK...", DateTime.Now);
            }
        }
        private Model.User SetUser()
        {
            Model.User user = new Model.User();
            bool validate = false;
            do
            {
                Console.Write("신규 회원의 아이디를 입력해주세요.");
                user.ID = Console.ReadLine();
                Console.Write("신규 회원의 이름을 입력해주세요.");
                user.Name = Console.ReadLine();
                Console.Write("신규 회원의 나이를 입력해주세요.");
                user.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("신규 회원의 직업을 입력해주세요.");
                user.Job = Console.ReadLine();

                Console.WriteLine("신규 회원 정보 : {0} / {1} / {2} / {3}",
                    user.ID, user.Name, user.Age, user.Job);
                Console.WriteLine("올바르게 입력되었습니까?(y/n)");
                validate = Console.ReadLine().ToLower() != "y";
            }
            while (validate);
            return user;
        }
    }
}