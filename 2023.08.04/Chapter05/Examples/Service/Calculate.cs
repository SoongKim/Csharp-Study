using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasic.Chapter05.Examples.Service
{
    public class Calculate
    {
        public int Sumation(int a, int b)
        {
            return a + b;
        }
        public int Minus(int a, int b)
        {
            return a - b;
        }
        public int Multiple(int a, int b)
        {
            return a * b;
        }
        public double Divide(int a, int b)
        {
            return (double)a / b;
        }
    }
}
