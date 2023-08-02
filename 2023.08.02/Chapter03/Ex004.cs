using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex004
    {
        public void Run()
        {
            Console.WriteLine("정수 하나를 입력해주세요.");
            int userNum = Convert.ToInt32(Console.ReadLine());
            if(userNum % 2 == 0)
            {
                Console.WriteLine("입력하신 정수 {0}은/는 짝수입니다.", userNum);
            }
            else
            {
                Console.WriteLine("입력하신 정수 {0}은/는 홀수입니다.", userNum);
            }
        }
    }
}
