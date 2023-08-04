using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples.Model
{
    public class FiveNumber
    {
        List<int> arr;
        public void Run()
        {
            arr = new List<int>();
            for(int idx = 0; idx < 5; idx++)
            {
                Console.WriteLine("숫자를 입력해주세요 : {0}개 남음", 5-(idx+1));
                arr.Add(Convert.ToInt32(Console.ReadLine()));
            }
            arr.Sort();
            Console.Write("오름차순 정렬 결과: ");
            for(int i = 0; i < arr.Count; i++)
            {
                if(i < arr.Count - 1)
                {
                Console.Write(arr[i]+", ");
                }
                else
                {
                    Console.Write(arr[i]);
                }
            }
            Console.ReadKey();
        }
    }
}