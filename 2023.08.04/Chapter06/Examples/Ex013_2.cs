using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex013_2
    {
        public void Run()
        {
            // List는 ArrayList의 상위 버전
            List<int> alist = new List<int>();
            for(int i = 0; i < 15; i++)
            {
                alist.Add(i);
            }
            alist.Insert(5, 100);

            for(int i = 0; i < alist.Count; i++)
            {
                Console.WriteLine("Value : {0} / Type : {1}",
                    alist[i], alist[i].GetType());
            }
            Console.WriteLine(alist.Count);

            Console.WriteLine();
            alist.RemoveAt(5);

            for (int i = 0; i < alist.Count; i++)
            {
                Console.WriteLine("Value : {0} / Type : {1}",
                    alist[i], alist[i].GetType());
            }
            Console.WriteLine(alist.Count);
        }
    }
}
