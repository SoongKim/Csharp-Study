using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Ex008
    {
        public void Run()
        {
            Random rand = new Random();
            int comSelNum = rand.Next(1, 50);
            int count = 0;
            int userSelNum;
            Console.WriteLine("1 ~ 50 중 숫자 하나를 골라주세요!");
            do
            {
                if(comSelNum > (userSelNum = Convert.ToInt32(Console.ReadLine())))
                {
                    Console.WriteLine("오답입니다! UP!");
                    count++;
                }
                else if(comSelNum < (userSelNum = Convert.ToInt32(Console.ReadLine())))
                {
                    Console.WriteLine("오답입니다! DOWN!");
                    count++;
                }
            }
            while (comSelNum == (userSelNum = Convert.ToInt32(Console.ReadLine())));
            
            if(comSelNum == userSelNum)
            {
                count++;
            Console.WriteLine("정답입니다! {0}이었으며 총 {1}회 플레이하셨습니다.", comSelNum, count+1);
            }
        }
    }
}
