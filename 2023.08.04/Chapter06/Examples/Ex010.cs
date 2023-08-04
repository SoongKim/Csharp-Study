using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex010
    {
        public void Run()
        {
            Stack stack = new Stack();

            Console.WriteLine("* 시작점");
            for (int idx = 0; idx < 10; idx++)
            {
                Console.WriteLine("{0}번 선수 도착", idx+1);
                stack.Push(string.Format("{0}번 선수", idx+1));
                // C#의 Queue에서는 입력 간 Add,
                // Stack은 입력 간 Push
            }
            Console.WriteLine("=======================");
            Console.WriteLine("5 - 10등 선수는 탈락합니다.");
            for (int idx = 0; idx < 5; idx++)
            {
                stack.Pop();
            }
            Console.WriteLine("=======================");
            Console.WriteLine("* 올림픽 대표선수 명단");
            foreach(object obj in stack)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
