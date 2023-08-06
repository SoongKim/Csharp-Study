using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class SortingProgram
    {
        public void Run()
        {
            List<double> myList = new List<double>();
            int index = 0;
            while(index < 5)
            {
                double userSelectNum = 0;
                Console.Write("숫자를 입력해주세요. : ");
                try
                {
                    userSelectNum = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("올바른 숫자를 입력해주세요.");
                    index--;
                    continue;
                }
                myList.Add(userSelectNum);
                index++;
            }
            myList.Sort();
            Console.WriteLine("오름차순 정렬 결과: {0}", string.Join(",", myList));
        }
    }
}
