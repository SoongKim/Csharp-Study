using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09.Example
{
    public class Ex004
    {
        //델리게이트 체이팅
        private delegate void RunCalc(int a, int b);

        private static void Sum(int number1, int number2)
        {
            Console.WriteLine("SUM : {0}", number1 + number2);
        }

        private static void Multiply(int number1, int number2)
        {
            Console.WriteLine("MULTI : {0}", number1 * number2);
        }
        
        private static void Divide(int number1, int number2)
        {
            Console.WriteLine("DIV : {0}", number1 / number2);
        }

        // Combine 기능을 통해 델리게이트 하나로 여러 메서드를 한 번에 동작한다.
        public void Run()
        {
            RunCalc calc = (RunCalc)Delegate.Combine
                           (new RunCalc(Sum), new RunCalc(Multiply),
                            new RunCalc(Divide));
            calc(20, 4);
        }
    }
}
