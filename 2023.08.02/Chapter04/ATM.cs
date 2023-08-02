using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class ATM
    {
        public void Run()
        {
            int account = 0;
            for (int i = 0; i < 99999; i++)
            {
                Console.WriteLine("************* 안녕하세요 Road Bank 입니다. *************");
                Console.WriteLine("1 : 잔액 조회");
                Console.WriteLine("2 : 입금");
                Console.WriteLine("3 : 출금");
                Console.WriteLine("0 : 종료");
                Console.WriteLine("********************************************************");
                try {
                    string menuSelectNum = Console.ReadLine();
                    if (menuSelectNum.Equals("1"))
                    {
                        Console.WriteLine("잔액은 '{0}'원 입니다.", account);
                    }
                    else if(menuSelectNum.Equals("2"))
                    {
                        Console.WriteLine("입금할 금액을 입력해주세요.");
                        try
                        {
                            int insertMoney = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("입금되었습니다.");
                            account += insertMoney;
                        }
                        catch
                        {
                            Console.WriteLine("올바른 금액을 입력해주세요.");
                        }
                    }
                    else if(menuSelectNum.Equals("3"))
                    {
                        Console.WriteLine("출금할 금액을 입력하세요.");
                        Console.WriteLine("잔액 : {0}원", account);
                        try
                        {
                            int withdrawMoney = Convert.ToInt32(Console.ReadLine());
                            if(account >= withdrawMoney)
                            {
                                Console.WriteLine("{0}원 출금되었습니다.", withdrawMoney);
                                account -= withdrawMoney;
                            }
                            else
                            {
                                Console.WriteLine("잔액을 초과하여 출금하실 수 없습니다.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("올바른 출금 액수를 입력해주세요.");
                        }
                    }
                    else if (menuSelectNum.Equals("0"))
                    {
                        Console.WriteLine("감사합니다.");
                        break;
                    }
                }
                catch 
                {
                    Console.WriteLine("올바른 메뉴 버튼을 입력해주세요.");
                }
                Console.WriteLine();
            }
        }
    }
}
