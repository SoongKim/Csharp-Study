using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex005
    {
        public void Run()
        {
            Console.WriteLine("정수를 하나 입력해주세요.");
            int userNum = Convert.ToInt32(Console.ReadLine());
            if(userNum > 0)
            {
                string typeNum = "양의 정수";
                Console.WriteLine("입력하신 정수 {0}은/는 {1} 입니다.", userNum, typeNum);
                Console.WriteLine();
                if (userNum % 2 == 0)
                {
                    Console.WriteLine("입력하신 {0} {1}은/는 짝수입니다.", typeNum, userNum);
                }
                else
                {
                    Console.WriteLine("입력하신 {0} {1}은/는 홀수입니다.", typeNum, userNum);
                }
            }
            else if(userNum < 0)
            {
                string typeNum = "음의 정수";
                Console.WriteLine("입력하신 정수 {0}은/는 {1} 입니다.", userNum, typeNum);
                Console.WriteLine();
                if (userNum % 2 == 0)
                {
                    Console.WriteLine("입력하신 {0} {1}은/는 짝수입니다.", typeNum, userNum);
                }
                else
                {
                    Console.WriteLine("입력하신 {0} {1}은/는 홀수입니다.", typeNum, userNum);
                }
            }
            else
            {
                Console.WriteLine("입력하신 정수는 {0}입니다.", userNum);
            }
        }
    }
}
