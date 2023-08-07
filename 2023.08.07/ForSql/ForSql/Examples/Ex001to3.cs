using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSql.Example
{
    public class Ex001to3
    {
        private readonly string pwd = Environment.CurrentDirectory;
        // pwd 변수에 현재 작업 중인 디렉토리 경로 정보를 저장
        public void Run()
        {
            #region
            DirectoryInfo drInfo = new DirectoryInfo(pwd + @"\newData");
            if(!drInfo.Exists)
            {
                drInfo.Create();
                Console.WriteLine("디렉토리가 생성되었습니다.");
                Console.WriteLine("생성경로 : {0}", drInfo.FullName);
                Console.WriteLine();
            }
            FileInfo fileInfo = new FileInfo(drInfo + @"\log.txt");
            if(!fileInfo.Exists)
            {
                fileInfo.Create();
                Console.WriteLine("로그 파일이 생성되었습니다.");
                Console.WriteLine("저장경로 : {0}", fileInfo.FullName);
                Console.WriteLine();
            }
            // 한 메서드는 하나의 기능만 수행하도록 설계한다.
            // 이번 코드는 디렉토리 생성, 로그 생성, 기록, 참조까지
            // 네 가지 기능을 수행하고 있다. 안 터지는게 이상한 거지...
            // 차라리 각 기능들을 세부적으로 나눠서 네 개의 Service 메서드를 생성하고,
            // 이를 호출하고 운용하는 Model 클래스를 설계했다면 더 안정적이었을 듯.
            #endregion

            Console.WriteLine("====================");
            Console.WriteLine();
            Boolean tryingProgram = true;
            StreamWriter sw = new StreamWriter(fileInfo.FullName, true);
            Console.WriteLine("프로그램을 기동합니다.");
            while (tryingProgram)
            {

                Console.WriteLine("기동시간을 기록합니다...");
                sw.WriteLine("기동시간 : {0}", DateTime.Now);
                Console.WriteLine("프로그램을 종료할까요? (y: 종료)");
                string isStop = Console.ReadLine().ToLower();
                if(isStop == "y")
                {
                    tryingProgram = false;
                    Console.WriteLine("프로그램을 종료합니다.");
                    Console.WriteLine("====================");
                }
            }
            sw.Close();
            StreamReader sr = new StreamReader(fileInfo.FullName);
            string line = string.Empty;
            Console.WriteLine("로그 파일을 출력합니다.");
            while((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
