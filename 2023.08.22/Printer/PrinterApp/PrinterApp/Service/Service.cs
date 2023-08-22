using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrinterApp.Model;

namespace PrinterApp.Model
{
    public class Service
    {
        public void Run()
        {
            PrinterModel settingBook = PrinterModel.getInstance();
            bool tryIng = true;
            Console.WriteLine("기록 프로그램을 기동합니다.");
            settingBook.OpeningBook();
            do
            {
                Console.WriteLine("***************************");
                Console.WriteLine("1: 기록합니다.");
                Console.WriteLine("2: 확인합니다.");
                Console.WriteLine("3: 제거합니다.");
                Console.WriteLine("0: 종료합니다.");
                Console.WriteLine("***************************");
                int userSelectMenu;
                try
                {
                    userSelectMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                    continue;
                }
                if (userSelectMenu == 1)
                {
                    settingBook.WritingBook();
                }
                else if(userSelectMenu == 2)
                {
                    settingBook.ReadingBook();
                }
                else if(userSelectMenu == 3)
                {
                    settingBook.RemoveBook();
                }
                else if(userSelectMenu == 0)
                {
                    settingBook.ClosingBook();
                    Console.WriteLine("프로그램을 종료합니다.");
                    break;
                }
            }
            while (tryIng);
        }
    }
}
