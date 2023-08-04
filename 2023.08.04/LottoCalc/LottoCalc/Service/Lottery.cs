using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoCalc.Service
{
    public  class Lottery
    {
        int[] arr;
        public int[] findNumber()
        {
            arr = new int[6];
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int index = 0;
            while(index < arr.Length)
            {
                int temp = random.Next(1, 45);
                if (!arr.Contains(temp))
                {
                    this.arr[index] = temp;
                    index++;
                }
                else if(arr.Contains(temp))
                {
                    continue;
                }
            }
            Array.Sort(arr);
            return arr;
        }
    }
}
