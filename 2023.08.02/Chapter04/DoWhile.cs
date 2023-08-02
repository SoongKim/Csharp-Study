using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class DoWhile
    {
        public void Run()
        {
            // do - while : 선 실행 후 조건. 최소 한 번은 반복문이 시행된다.
            // while : 선 조건 후 실행. 반복문이 한 번도 시행되지 않을 수 있다.
            Random random = new Random();
            int targetNumber = random.Next(1, 10);

            Console.WriteLine("제가 생각하고 있는 1 ~ 10 사이의 숫자를 맞춰보세요.");
            int count = 0;
            bool isMatched = false;
            do
            {
                if (Convert.ToInt32(Console.ReadLine()) == targetNumber)
                {
                    isMatched = true;
                    Console.WriteLine("정답입니다. 맞추기까지 {0}번 소요되었습니다.", count);
                }
                else
                {
                    Console.WriteLine("틀렸습니다.");
                    count++;
                }
            }
            while (!isMatched);
        }
    }
}
