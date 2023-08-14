using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda.Example
{
    internal class Ex002
    {
        private delegate int RunCalc(int a, int b);
        public void Run()
        {
            // 델리게이트 + 람다식 사용법
            // if 조건문도 사용할 수 있다.
            RunCalc calc = (a, b) => a + b;
            Console.WriteLine(calc(1, 2));
            calc = (a, b) => a * b;
            Console.WriteLine(calc(3, 5));
        }
    }
}
