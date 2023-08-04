using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex009
    {
        // 자료구조 : Queue은 선입선출!
        //        <-> Stack은 후입선출!
        public void Run()
        {
            Queue que = new Queue();
            for (int idx = 1; idx < 11; idx++)
            {
                que.Enqueue(string.Format("{0}번 승객", idx));
            }
            Console.WriteLine("* 정류장 승객 현황");
            foreach (object obj in que)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine("==================");
            Console.WriteLine("버스가 도착했습니다. ({0}명 승차 가능)",
                que.Count);
            // Queue.Count = (java) Queue.size();

            for (int i = 0; i < 6; i++)
            {
                que.Dequeue();
            }
            Console.WriteLine("버스가 출발했습니다.");
            Console.WriteLine("==================");

            Console.WriteLine("* 정류장 승객 현황");
            foreach (object obj in que)
            {
                Console.WriteLine(obj.ToString());
            }
            Console.WriteLine("==================");
        }
    }
}
