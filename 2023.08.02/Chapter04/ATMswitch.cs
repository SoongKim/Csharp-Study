using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    internal class ATMswitch
    {
        public void Run()
        {
            int account = 0;
            for (int i = 0; i < 999999; i++)
            {
                Console.WriteLine("************* 안녕하세요 Road Bank 입니다. *************");
                Console.WriteLine("1 : 잔액 조회");
                Console.WriteLine("2 : 입금");
                Console.WriteLine("3 : 출금");
                Console.WriteLine("0 : 종료");
                Console.WriteLine("********************************************************");

                try
                {
                    int userMenuSelect = Convert.ToInt32(Console.ReadLine());
                    if (userMenuSelect >= 4)
                    {
                        Console.WriteLine("올바른 메뉴 버튼을 입력해주세요.");
                        break;
                    }
                    
                    switch (userMenuSelect)
                    {
                        case 0:
                            Console.WriteLine("감사합니다.");
                            Console.WriteLine();
                            break;
                        case 1:
                            Console.WriteLine("잔액은 '{0}'원 입니다.", account);
                            continue;
                        case 2:
                            Console.WriteLine("입금할 금액을 입력해주세요.");
                            try
                            {
                                int insertMoney = Convert.ToInt32(Console.ReadLine());
                                account += insertMoney;
                                Console.WriteLine("{0}원 입금되었습니다.", insertMoney);
                            }
                            catch
                            {
                                Console.WriteLine("올바른 입금액을 입력해주세요.");
                            }
                            continue;
                        case 3:
                            Console.WriteLine("출금할 금액을 입력해주세요.");
                            Console.WriteLine("잔액 : '{0}'원", account);
                            try
                            {
                                int withDrawMoney = Convert.ToInt32(Console.ReadLine());
                                if (account >= withDrawMoney)
                                {
                                    account -= withDrawMoney;
                                    Console.WriteLine("총 '{0}'원 인출되었습니다.", withDrawMoney);
                                }
                                else
                                {
                                    Console.WriteLine("보유고를 초과하여 인출할 수 없습니다.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("올바른 출금액을 입력해주세요.");
                            }
                            continue;
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