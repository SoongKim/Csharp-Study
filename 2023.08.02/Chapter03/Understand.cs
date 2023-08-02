using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Understand
    {
        Random rand = new Random();
        public void Run()
        {
            int target = rand.Next(1, 100);
            Console.WriteLine("첫 번째 난수는 {0} 입니다.", target);
            int nextTarget = rand.Next(1, 100);
            Console.WriteLine("두 번째 난수는 {0} 입니다.", nextTarget);
            Console.WriteLine("두 수의 합을 입력해주세요.");
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            int answer = target + nextTarget;

            if(userAnswer == answer)
            {
                Console.WriteLine("정답입니다!");
            }
            else
            {
                Console.WriteLine("틀렸습니다...");
            }
        }
    }
}
