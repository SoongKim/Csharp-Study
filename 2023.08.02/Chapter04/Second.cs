using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Second
    {
        public void Run()
        {
            Random rand = new Random();
            int targetNumber = rand.Next(1, 10);
            Console.WriteLine("제가 생각하고 있는 1~10 사이의 숫자를 맞춰보세요.");
            Console.WriteLine("0을 입력하시면 힌트를 드립니다.");
            int count = 0;
            int answer = 0;
            while((answer = Convert.ToInt32(Console.ReadLine())) != targetNumber)
            {
                if(answer == 0)
                {
                    Console.WriteLine("힌트: 제가 생각하고 있는 숫자는 2로 나누었을 때" +
                        "나머지가 {0}입니다.", (targetNumber % 2));
                }
                Console.WriteLine("틀렸습니다!");
                count++;
            }
            Console.WriteLine("정답입니다. 맞추기까기 {0}회 걸리셨습니다!", count);
        }
    }
}
