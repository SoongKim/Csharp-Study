using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSql.Example
{
    public class Ex003
    {
        private readonly string currentDirectory =
            Environment.CurrentDirectory;
        public void Run()
        {
            FileInfo fileInfo = new FileInfo(currentDirectory + @"\data\log.txt");

            Console.WriteLine("저장경로 : {0}", fileInfo.DirectoryName);
            Console.WriteLine("파일명 : {0}", fileInfo.Name);

            Console.WriteLine("===== 파일 내용 ===");
            StreamReader sr = new StreamReader(fileInfo.FullName);
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            #region
            // fileInfo.FullName에 위치한 파일을 StreamReader로 읽어와
            // 파일로부터 새로 읽어온 줄이 비어있지 않을 때까지
            // 화면에 출력한다.
            #endregion
        }
    }
}
