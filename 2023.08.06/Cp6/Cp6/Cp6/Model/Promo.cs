using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class Promo
    {
        Queue<string> myQ;
        public void Run()
        {
            myQ = new Queue<string>();
            int userCount = 0;
            Boolean validCount = false;
            while(validCount == false)
            {
                Console.Write("몇 명의 인원에게 무료 혜택을 제공할까요?");
                try
                {
                    userCount = Convert.ToInt32(Console.ReadLine());
                    validCount = true;
                }
                catch
                {
                    Console.WriteLine("입력을 확인해주세요.");
                }
            }while(true)
            {
                Console.Write("이름을 입력해주세요(q: 종료)");
                string inputInfo = Console.ReadLine();
                if(inputInfo == "q")
                {
                    break;
                }
                myQ.Enqueue(inputInfo);
            }
            Console.WriteLine("무료 영화 관람권 당첨자는");
            for(int idx = 0; idx < userCount; idx++)
            {
                Console.WriteLine(myQ.Dequeue());
            }
            Console.WriteLine("입니다.");
        }
    }
}
