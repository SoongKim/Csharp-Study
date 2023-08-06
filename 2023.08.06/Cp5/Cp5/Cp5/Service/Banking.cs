using Cp5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp5.Service
{
    public class Banking
    {
        Model.Bank bank;
        public Banking()
        {
            this.bank = new Model.Bank();
        }
        public Banking(Model.Bank bank)
        {
            this.bank = bank;
        }

        public void openAccount()
        {
            Console.WriteLine("통장 고유이름을 입력해주세요.");
            bank.accountName = Console.ReadLine();
            Console.WriteLine("통장 개설자의 이름을 입력하세요.");
            bank.userName = Console.ReadLine();
            Console.WriteLine("'{0}' 님의 '{1}' 이 개설되었습니다.",
                bank.userName, bank.accountName);
        }
        public void checkMoney()
        {
            Console.WriteLine("잔액은 '{0}' 원입니다.", bank.accountMoney);
        }
        public void inputMoney()
        {
            Console.WriteLine("입금할 금액을 입력하세요.");
            Boolean isValid = false;
            int insertMoney = 0;
            try
            {
                insertMoney = Convert.ToInt32(Console.ReadLine());
                isValid = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("올바른 금액을 입력해주세요.");
                Console.WriteLine(e.HResult);
                Console.WriteLine(e.Message);
            }
            if (isValid)
            {
                bank.accountMoney += insertMoney;
                Console.WriteLine("입금되었습니다.");
            }
        }
        public void withDraw()
        {
            Console.WriteLine("출금할 금액을 입력하세요.");
            int withDrawMoney = 0;
            Boolean isValid = false;
            try
            {
                withDrawMoney = Convert.ToInt32(Console.ReadLine());
                isValid = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("오류가 발생하였습니다.");
                Console.WriteLine(e.HResult);
                Console.WriteLine(e.Message);
            }

            if (isValid)
            {
                if (bank.accountMoney >= withDrawMoney)
                {
                    bank.accountMoney -= withDrawMoney;
                    Console.WriteLine("출금되었습니다.");
                }
                else
                {
                    Console.WriteLine("잔액이 부족합니다!");
                }
            }
        }
        public void Run()
        {
            Service.Banking banking = new Service.Banking();
            Boolean trying = true;
            while (trying)
            {
                Console.WriteLine("******* 안녕하세요 Road Bank입니다." +
                    "*******");
                Console.WriteLine("1: 계좌 만들기");
                Console.WriteLine("2: 잔액 조회");
                Console.WriteLine("3: 입금");
                Console.WriteLine("4: 출금");
                Console.WriteLine("0: 종료");
                Console.WriteLine("***********************************" +
                    "*******");
                Console.WriteLine();
                string userSelectMenu = Console.ReadLine();
                if (userSelectMenu == "1")
                {
                    banking.openAccount();
                }
                else if (userSelectMenu == "2")
                {
                    banking.checkMoney();
                }
                else if (userSelectMenu == "3")
                {
                    banking.inputMoney();
                }
                else if (userSelectMenu == "4")
                {
                    banking.withDraw();
                }
                else if (userSelectMenu == "0")
                {
                    Console.WriteLine("감사합니다.");
                    trying = false;
                }
                Console.WriteLine();
            }
        }
    }
}