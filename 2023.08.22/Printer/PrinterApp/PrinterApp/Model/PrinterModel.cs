using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrinterApp.Model
{
    public class PrinterModel
    {
        private static PrinterModel printer = new PrinterModel();
        private PrinterModel() { }
        private readonly string currentDir = Environment.CurrentDirectory;
        bool isRunning;

        public static PrinterModel getInstance()
        /* Lazy Initialization + Double-Checking Locking 방식을 사용 */
        {
            if (printer == null)
            {
            printer = new PrinterModel();
            }
            return printer;
        }
        public void OpeningBook()
        {
            Console.WriteLine("책장을 엽니다.");
            printer.isRunning = true;
        }
        public void ClosingBook()
        {
            Console.WriteLine("책장을 덮습니다.");
            printer.isRunning = false;
        }
        public void WritingBook()
        {
            DirectoryInfo logFileInfo = new DirectoryInfo(printer.currentDir + @"\data");
            if (!logFileInfo.Exists)
            {
                Console.WriteLine("로그 파일 경로를 생성합니다. 경로 : {0}", logFileInfo.FullName+@"\data");
                logFileInfo.Create();
            }
            else
            {
                Console.WriteLine("로그 파일 대상 경로 : {0}", logFileInfo.FullName);
            }
            bool isValid = true;
            StreamWriter sw = new StreamWriter(logFileInfo.FullName + @"\printingPage.txt", true);
            Console.WriteLine("기록하실 문구를 적어주세요. (Q: 종료)");
            while (isValid)
            {
                string userInput = Console.ReadLine();
                if (userInput == "Q")
                {
                    sw.WriteLine("***************************");
                    isValid = false;
                    break;
                }
                else
                {
                    sw.WriteLine(userInput);
                }
            }
            Console.WriteLine("기록을 종료합니다.");
            sw.Close();
        }

        public void ReadingBook()
        {
            DirectoryInfo logDirInfo = new DirectoryInfo(currentDir + @"\data");
            if (!logDirInfo.Exists)
            {
                Console.WriteLine("기록 폴더가 존재하지 않습니다.");
                return;
            }
            FileInfo fileinfo = new FileInfo(logDirInfo.FullName+ @"\printingPage.txt");
            if (!fileinfo.Exists)
            {
                Console.WriteLine("읽어올 기록이 존재하지 않습니다. 작성 후 열람해주세요.");
                return;
            }
            string logDirectory = fileinfo.FullName;
            Console.WriteLine("기록된 내용을 화면에 출력합니다.");
            Console.WriteLine();
            Console.WriteLine("***************************");
            Console.WriteLine();
            using(StreamReader sr = new StreamReader(logDirectory))
            {
                while(!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
                Console.WriteLine();
            }
        }
        public void RemoveBook()
        {
            Console.WriteLine("지금까지 기록한 사항들을 모두 제거합니다. Y : 제거");
            string userInput = Console.ReadLine();
            if(userInput == "Y")
            {
                FileInfo fileinfo = new FileInfo(currentDir + @"\data\printingPage.txt");
                fileinfo.Delete();
                Console.WriteLine("기록 사항이 모두 제거되었습니다.");
            }
        }
    }
}