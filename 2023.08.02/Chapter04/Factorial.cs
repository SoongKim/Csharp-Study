using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Factorial
    {
        public void Run()
        {
            Console.WriteLine("숫자를 하나 입력해주세요.");
            int userNum = Convert.ToInt32(Console.ReadLine());
            int answer = 1;
            for(int i = 1; i <= userNum; i++)
            {
                answer = answer * i;
            }
            Console.WriteLine("{0}!의 값은 {1} 입니다.", userNum, answer);
        }
    }
}
