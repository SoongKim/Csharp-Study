using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples.Model
{
    public class Promotion
    {
        Queue<string> myQ;
        public void Run()
        {
            Console.WriteLine("몇 명의 인원에게 혜택을 제공할까요?");
            int countNum = Convert.ToInt32(Console.ReadLine());
            myQ = new Queue<string>();
            while (true)
            {
                Console.WriteLine("이름을 입력해주세요(q: 종료)");
                string userName = Console.ReadLine();
                if (userName.ToLower() != "q")
                {
                    myQ.Enqueue(userName);
                }
                else
                {
                    break;
                }
            }
            
            Console.WriteLine("무료 영화 당첨자는");
            for(int idx = 0; idx < countNum; idx++)
            {
                Console.WriteLine(myQ.Dequeue());
            }
        }
    }
}
