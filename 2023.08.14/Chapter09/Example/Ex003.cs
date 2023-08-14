using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09.Example
{
    public class Ex003
    {
        private delegate int RunCalc(int a, int b);
        private static int Sum(int number1, int number2)
        {
            return number1 + number2;
        }
        private static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        public void Run()
        {
            RunCalc calc = delegate (int a, int b)
            {
                return a / b;
            };
            Console.WriteLine(calc(10, 2));
        }
        // 델리게이트(Delegate)를 사용하는 이유!
        #region
        // 1. 별도 메서드를 생성하지 않아도 되는, 한 번 사용하면 불필요해지는
        //    기능을 사용하여야 할 때.
        #endregion
    }
}
