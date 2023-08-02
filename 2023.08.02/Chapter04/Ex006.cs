using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class Ex006
    {
        public void Run()
        {
            for(int i = 2; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    Console.WriteLine("{0} 곱하기 {1} 은/는 {2} 입니다.", i, j, i * j);
                }
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
            }
        }
    }
}
