using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public class BankingService
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;
        Model.AccountUnit unit = new Model.AccountUnit();
        public void Run()
        {
            bool isValid = true;
            while (isValid)
            {
                Console.WriteLine("******* 안녕하세요 Road Bank입니다. *******");
                Console.WriteLine("1: 계좌 만들기");
                Console.WriteLine("2: 잔액 조회");
                Console.WriteLine("3: 입금");
                Console.WriteLine("4: 출금");
                Console.WriteLine("0: 종료");
                Console.WriteLine("*******************************************");
                string menuSelect;
                try
                {
                    menuSelect = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                    continue;
                }
                if (menuSelect == "1")
                {
                    newAccount();
                }
                else if (menuSelect == "2")
                {
                    countMoney();
                }
                else if (menuSelect == "3")
                {
                    InsertMoney();
                }
                else if (menuSelect == "4")
                {
                    WithdrawMoney();
                }
                else if (menuSelect == "0")
                {
                    Console.WriteLine("감사합니다.");
                    makingLogFile();
                    break;
                }
                else
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                    continue;
                }
            Console.WriteLine();
            }
        }

        private void newAccount()
        {

            Console.WriteLine("통장 고유이름을 입력하세요.");
            unit.accountName = Console.ReadLine();
            Console.WriteLine("통장 개설자의 이름을 입력하세요.");
            unit.userName = Console.ReadLine() + "통장";
            Console.WriteLine("'{0}' 님의 '{1}' 이 개설되었습니다.", unit.userName, unit.accountName);
        }

        private void InsertMoney()
        {
            Console.WriteLine("입금할 금액을 입력하세요.");
            int targetMoney = Convert.ToInt32(Console.ReadLine());
            unit.accountMoney += targetMoney;
            Console.WriteLine("입금되었습니다.");
        }

        private void WithdrawMoney()
        {
            Console.WriteLine("출금할 금액을 입력하세요.");
            int withDrawMoney = 0;
            try
            {
                withDrawMoney = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("올바른 금액을 입력해주세요.");
            }

            if (withDrawMoney > unit.accountMoney)
            {
                Console.WriteLine("잔액이 부족합니다!");
            }
            else
            {
                Console.WriteLine("출금되었습니다.");
            }
        }

        private void countMoney()
        {
            Console.WriteLine("잔액은 '{0}'원입니다.", unit.accountMoney);
        }

        private void makingLogFile()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(currentDirectory + @"\data");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            FileInfo fileinfo = new FileInfo(dirInfo + @"\log.txt");
            StreamWriter sw = new StreamWriter(fileinfo.FullName, true);
            sw.WriteLine("잔액 : '{0}'원", unit.accountMoney);
            Console.WriteLine("잔액을 로그 파일에 기록합니다. 잔액 : {0}", unit.accountMoney);
        }
    }
}
