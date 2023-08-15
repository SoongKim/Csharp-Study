using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review8to9.Example
{
    // Ex001 : 기동 시점을 CurrentDirectory+"@\data\log.txt"파일에 저장.
    //         true 조건을 붙여 덮어쓰지 않고, 덧붙여 쓴다.
    internal class Ex001
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;
        public void Run()
        {
            FindDirectory();
            UsingStrWriter();
        }

        private void FindDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory + @"\data");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("디렉토리가 생성되었습니다. 경로 : {0}", dirInfo.FullName);
            }
            else
            {
                Console.WriteLine("대상 경로 : {0}", dirInfo.FullName);
            }
        }

        private void UsingStrWriter()
        {
            StreamWriter sw = new StreamWriter(currentDirectory + @"\data\log.txt", true);
            sw.WriteLine("프로그램 기동 : {0}", DateTime.Now);
            Console.WriteLine("프로그램 기동 시점을 기록하였습니다. {0}", DateTime.Now);
            sw.Close();
        }
    }
}
