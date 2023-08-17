using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewChapter05.Service
{
    public class BankService
    {
        Model.Bank account;
        public void bankService()
        {
            this.account = new Model.Bank();
        }
        public void bankService(Model.Bank account)
        {
            this.account = account;
        }

        public void SetAccount()
        {
            Console.WriteLine("계좌명을 입력해주세요.");
            this.account.accountName = Console.ReadLine();
            Console.WriteLine("계좌 소유주명을 입력해주세요.");
            this.account.accountOwner = Console.ReadLine();
            this.account.accountMoney = "0";
        }


        public void FindMyMoney()
        {
            Console.WriteLine("'{0}' 계좌 잔액은 '{1}'원 입니다.", this.account.accountName, Convert.ToInt32(this.account.accountMoney));
        }

        public void inputMoney()
        {
            Console.WriteLine("입금액을 입력해주세요. 잔액 : {0}", this.account.accountMoney);
            int inputMoney;
            try
            {
                inputMoney = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("올바른 입금액을 입력해주세요.");
                return;
            }
            this.account.accountMoney = (Convert.ToInt32(this.account.accountMoney) + inputMoney).ToString();
            Console.WriteLine("'{0}'원 입금되었습니다. 잔액 : '{1}'원", inputMoney, Convert.ToInt32(this.account.accountMoney));
        }

        public void Run()
        {
            bool isValid = true;
            do
            {
                Console.WriteLine("***** 안녕하세요 은행입니다. *****");
                Console.WriteLine("1: 계좌 만들기");
                Console.WriteLine("2: 잔액 조회");
                Console.WriteLine("3: 입금");
                Console.WriteLine("4: 출금");
                Console.WriteLine("0 : 종료");
                Console.WriteLine("**********************************");
                int userSelMenu = -1;
                try
                {
                userSelMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                    continue;
                }
                if(userSelMenu == 1)
                {
                    bankService();
                    SetAccount();
                    Console.WriteLine("계좌가 생성되었습니다.");
                }
                else if(userSelMenu == 2)
                {
                    FindMyMoney();
                }
                else if(userSelMenu == 3)
                {
                    inputMoney();
                }
                else if(userSelMenu == 4)
                {

                }
                else if(userSelMenu == 0)
                {
                    Console.WriteLine("감사합니다.");
                    isValid = false;
                }

            }
            while (isValid);
        }
    }
}
