using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples.Model
{
    public class Practice
    {
        public void Run()
        {
            Queue<int>myQ = new Queue<int>();
            Console.WriteLine("대상 인원의 수를 입력해주세요.");
            try
            {
                int userCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("{0}명의 나이를 입력받습니다.", userCount);
                for(int idx = 0; idx < userCount; idx++)
                {
                    Console.WriteLine("{0}번째 사람의 나이를 입력해주세요.", idx + 1);
                    myQ.Enqueue(Convert.ToInt32(Console.ReadLine()));
                }
                Console.WriteLine("나이 입력이 완료되었습니다.");
            }
            catch
            {
                Console.WriteLine("올바른 명수를 입력해주세요.");
            }
            Console.WriteLine();
            int underTwenty = 0;
            int twentyCount = 0;
            int thirtyCount = 0;
            int fourtyCount = 0;
            int fiftyCount = 0;
            int overSixty = 0;
            foreach(int idx in myQ){
                if(idx < 20)
                {
                    underTwenty++;
                }
                else if(idx < 30)
                {
                    twentyCount++;
                }
                else if(idx < 40)
                {
                    thirtyCount++;
                }
                else if(idx < 50)
                {
                    fourtyCount++;
                }
                else if(idx <60)
                {
                    fiftyCount++;
                }
                else
                {
                    overSixty++;
                }
            }
            Console.WriteLine("20대 미만: {0}명", underTwenty);
            Console.WriteLine("20대 : {0}명", twentyCount);
            Console.WriteLine("30대 : {0}명", thirtyCount);
            Console.WriteLine("40대 : {0}명", fourtyCount);
            Console.WriteLine("50대 : {0}명", fiftyCount);
            Console.WriteLine("60대 이상: {0}명", overSixty);
            Console.ReadKey();
        }
    }
}
