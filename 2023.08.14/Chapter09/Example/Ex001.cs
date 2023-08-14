using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09.Example
{
    public class Ex001
    {
        public void Run()
        {
            int[] number = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> tmpNumbers = new List<int>();

            for (int idx = 0; idx < number.Length; idx++)
            {
                if (number[idx] % 2 == 0)
                {
                    tmpNumbers.Add(number[idx]);
                }
            }
            for (int idx = 0; idx < tmpNumbers.Count; idx++)
            {
                Console.WriteLine(tmpNumbers[idx]);
            }
            tmpNumbers.Clear();

            Console.WriteLine();

            tmpNumbers = number.Where(n => (n%2) == 1).ToList();
            for(int idx = 0; idx < tmpNumbers.Count; idx++)
            {
                Console.WriteLine(tmpNumbers[idx]);
            }

        }
    }
}
