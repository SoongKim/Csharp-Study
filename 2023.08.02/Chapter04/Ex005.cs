using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Ex005
    {
        public void Run()
        {
            const int _number = 5;
            int answer = 1;
            for(int i = 1; i <= _number; i++)
            {
                answer = answer * i;
                Console.WriteLine("{0}을/를 곱합니다. 현재 값은 {1} 입니다.", i, answer);
                Console.WriteLine();
            }
            Console.WriteLine("{0}!의 값은 {1} 입니다.", _number, answer);
            // 코드의 Depth(뎁스, 깊이)는 최대 2 뎁스 까지를 지향하라.
            // 즉, 2중 포문을 넘어선 3~ 중 이상의 포문을 지양하라!
        }
    }
}
