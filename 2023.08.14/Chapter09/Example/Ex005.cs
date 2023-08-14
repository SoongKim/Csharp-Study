using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09.Example
{
    public class Ex005
    {
        // 람다식
        private delegate int RunCalc(int a, int b);

        public void Run()
        {
            RunCalc calc = (a, b) => a + b;
            Console.WriteLine(calc(1, 2));

            calc = (a, b) => a * b;
            Console.WriteLine(calc(1, 2));
            // 초기화도 필요 없고, => 를 사용하는 것만으로 굉장히 코드가 간결해진다.
            RunCalc calC = (a, b) =>
            {
                if (a > b) { return a + b; }
                else if (a < b) { return a / b; }
                else { return 0; }
            };
        }
    }
}
