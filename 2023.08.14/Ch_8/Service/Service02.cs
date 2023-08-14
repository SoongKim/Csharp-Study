using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08.Service
{
    public class Service02
    {
        private readonly string connectStr =
            string.Format("Data Source={0},{1}; Initial Catalog={2}; User ID={3}; Password={4}",
                "127.0.0.1", 1433, "testdb2", "sa", "kj920412");
        public void Run()
        {
            Console.WriteLine("참조 테이블 명을 입력해주세요,");
            string tableName = Console.ReadLine();
            string selectQuery = "SELECT ID, NAME, AGE, JOB FROM " + tableName + ";";

            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    SqlDataReader sr = command.ExecuteReader();
                    while (sr.Read())
                    {
                        Console.WriteLine("회원ID : {0}", sr["ID"]);
                        Console.WriteLine("회원이름 : {0}", sr["NAME"]);
                        Console.WriteLine("회원연령 : {0}", sr["AGE"]);
                        Console.WriteLine("회원직업 : {0}", sr["JOB"]);
                        Console.WriteLine("=====================");
                    }
                }
                connection.Close();
            }
        }
    }
}
