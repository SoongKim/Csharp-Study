using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class While
    {
        public void Run()
        {
            Random rand = new Random();
            int targetNumber = rand.Next(1, 10);
            Console.WriteLine("제가 생각하고 있는 1 ~ 10 사이 숫자를 맞춰보세요.");

            int count = 0;
            while(Convert.ToInt32(Console.ReadLine()) != targetNumber)
            {
                Console.WriteLine("틀렸습니다!");
                count++;
            }
            Console.WriteLine("정답입니다! 총 {0}회 걸리셨습니다!", count);
        }
    }
}
