using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    internal class Ex007
    {
        public void Run()
        {
            Random random = new Random();
            int comSelNum = random.Next(1, 50);
            Console.WriteLine(comSelNum);
            Console.WriteLine("1 ~ 50까지의 숫자 중 하나가 선택되었습니다. 정답을 맞춰주세요.");
            int count = 0;
            int userSelNum;
            while((userSelNum = Convert.ToInt32(Console.ReadLine())) != comSelNum)
            {
                if(userSelNum > comSelNum)
                {
                    Console.WriteLine("틀렸습니다! DOWN!");
                    count++;
                }
                else if(userSelNum < comSelNum)
                {
                    Console.WriteLine("틀렸습니다! UP!");
                    count++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("정답입니다! {0}이었으며, 총 {1}회 플레이하셨습니다.", comSelNum, count+1);
        }
    }
}
