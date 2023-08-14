using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda.Example
{
    internal class Programmers01
    {
        public int Solution(int n)
        {
            int answer = 0;
            int index = 2;
            while(index < n)
            {
                if(n % index == 1)
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            answer = index;
            return answer;
        }
        public void Run()
        {
            int answer = Solution(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(answer);
        }
    }
}
