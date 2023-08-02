using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex006
    {
        public void Run()
        {
            Console.WriteLine("숫자를 입력하세요.");
            int userNum = Convert.ToInt32(Console.ReadLine());

            bool isOddNumber =((userNum % 2 == 1) ? true: false);
            #region >> 3항 연산자란?
            // (조건) ? 참일 경우의 값 : 거짓일 경우의 값
            // 의 구조를 지니고 있습니다.
            // 변수 값 제어 간 참 / 거짓을 판별하는 때에만 한정적으로 사용합시다. 코드가 복잡해져요...
            #endregion
            if (userNum > 0 && isOddNumber)
            {
                Console.WriteLine("입력하신 정수는 양의 정수이며, 홀수입니다.");
            }
            else if(userNum > 0 && !isOddNumber)
            {
                Console.WriteLine("입력하신 정수는 양의 정수이며, 짝수입니다.");
            }
            else if(userNum < 0 && isOddNumber)
            {
                Console.WriteLine("입력하신 정수는 음의 정수이며, 홀수입니다.");
            }
            else if(userNum < 0 && !isOddNumber)
            {
                Console.WriteLine("입력하신 정수는 음의 정수이며, 짝수입니다.");
            }
            else
            {
                Console.WriteLine("입력하신 정수는 0이며, 짝수입니다.");
            }
        }
    }
}
