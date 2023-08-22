using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Example
{
    public class ExClass
    {
        SingletonClass singleTon = SingletonClass.getInstance();
        public void Run()
        {
            bool isValid = false;
            do
            {
                Console.WriteLine("*************");
                Console.WriteLine("1 : 주행 시작");
                Console.WriteLine("2 : 주차 이행");
                Console.WriteLine("3 : 주행 확인");
                Console.WriteLine("0 : 기동 종료");
                Console.WriteLine("*************");
                int userSelectMenu;
                try
                {
                    userSelectMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("올바른 메뉴를 입력해주세요.");
                    break;
                }
                if (userSelectMenu == 1)
                {
                    
                }
                else if (userSelectMenu == 2)
                {
                    
                }
                else if (userSelectMenu == 3)
                {

                }
                else if (userSelectMenu == 0)
                {
                    Console.WriteLine("감사합니다.");
                    break;
                }
                else
                {
                    Console.WriteLine("올바른 메뉴를 선택해주세요.");
                }
            }
            while (isValid);
        }

    }
}
