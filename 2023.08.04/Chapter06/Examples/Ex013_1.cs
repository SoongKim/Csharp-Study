using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex013_1
    {
        public void Run()
        {
            int alpha = 3;
            object obj = alpha;
            Console.WriteLine("int alpha의 데이터 타입은 {0}", alpha.GetType());
            Console.WriteLine("object obj의 데이터 타입은 {0}", obj.GetType());

            obj = (int)obj;
            Console.WriteLine("Unboxing 후 obj의 데이터 타입은 {0}", obj.GetType());
        }
    }
}
