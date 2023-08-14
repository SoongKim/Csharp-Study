using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09.Example
{
    public class Ex002
    {
        private delegate int RunCalc(int a, int b);
        //델리케이트
        #region
        // 사용할 변수 가짓수와, 타입만을 지니는 빈 메서드(델리게이트)를 선언.
        // 이후 사용 변수 조건에 부합하는 메서드들을 델리게이트에 덮어 쓴다.
        #endregion

        private static int Sum(int number01, int number02)
        {
            return number01 + number02;
        }
        private static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        public void Run()
        {
            RunCalc calc = Sum;
            Console.WriteLine(calc(1, 2));
            calc = Multiply;
            Console.WriteLine(calc(1, 2));
        }

    }
}
