using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review8to9.Example
{
    // Ex002 : CurrentDirectory+"\data\log.txt" 파일의 조회 및 화면 출력
    internal class Ex002
    {
        private readonly string logDirectory = Environment.CurrentDirectory + @"\data";

        public void Run()
        {
            ReadLogFile();
        }
        private void ReadLogFile()
        {
            string fileNameInfo;
            try
            {
                fileNameInfo = logDirectory + @"\log.txt";
            }
            catch
            {
                Console.WriteLine("대상 로그 파일이 존재하지 않습니다.");
                Console.WriteLine("프로그램을 종료합니다.");
                return;
            }
            StreamReader sr = new StreamReader(fileNameInfo);
            string line = string.Empty;
            Console.WriteLine("=======================");
            Console.WriteLine("로그 파일을 출력합니다.");
            do
            {
                Console.WriteLine(line);
            }
            while ((line = sr.ReadLine()) != null);
            Console.WriteLine("=======================");
        }
    }
}
