using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Ex004
    {
        public void Run()
        {
            int number = 10;
            Console.WriteLine(number++);
            // 변수++는 대상 명령 수행 후 카운트를 올리고
            Console.WriteLine(++number);
            // ++변수는 먼저 카운트를 올리고 명령을 수행한다.
            // ==> number(==10)을 출력한 후 카운트를 올려 number는 11이 됐다.
            // 그 후, 두 번째 출력 전 카운트+1이 먼저 이뤄지고, 출력이 진행되므로 number = 12,
            // 10과 12가 출력되었다.
        }
    }
}
