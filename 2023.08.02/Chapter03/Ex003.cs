using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex003
    {
        public void Run()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("숫자를 입력해주세요. {0}회 반복합니다", (5 - i));
                double userNum = Convert.ToDouble(Console.ReadLine());
                if (userNum > 0)
                {
                    Console.WriteLine("입력한 숫자는 양수입니다.");
                }
                else if (userNum == 0)
                {
                    Console.WriteLine("입력하신 숫자는 0입니다.");
                }
                else
                {
                    Console.WriteLine("입력하신 숫자는 음수입니다.");
                }
            }
        }
    }
}
