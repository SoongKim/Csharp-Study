using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex006
    {
        public void Run()
        {
            ArrayList arr = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                arr.Add(i);
            }
            for (int i = 10; i < 15; i++)
            {
                arr.Add(i.ToString());
            }
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Vallue : {0} / Type : {1}",
                    arr[i], arr[i].GetType());
            }
        }
    }
}