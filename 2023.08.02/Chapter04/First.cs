using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04.Lab
{
    public class First
    {
        const int _number = 2;
        public void Run()
        {
            for(int i = 1; i < 10; i++)
            {
                Console.WriteLine("{0} * {1} = {2}", _number, i, _number * i);
                Console.WriteLine();
            }
        }
    }
}
