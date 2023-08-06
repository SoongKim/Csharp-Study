using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class AgeInfo
    {
        public void Run()
        {
            List<int> myList = new List<int>();
            int totalCount = 0;
            Boolean countingVar = false;
            while (countingVar == false)
            {
                Console.WriteLine("인원 수를 입력해주세요.");
                try
                {
                    totalCount = Convert.ToInt32(Console.ReadLine());
                    countingVar = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("올바른 인원 수를 입력해주세요.");
                }
            }
            
            for(int idx = 0; idx < totalCount; idx++)
            {
                Console.Write("{0}번째 사람의 나이를 입력하세요 : ", (idx + 1));
                Boolean validAge = true;
                int userAge = 0;
                try
                {
                    userAge = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("오류가 발생하였습니다");
                    Console.WriteLine("프로그램을 중지합니다.");
                    break;
                }
                
                if(validAge)
                {
                    if (userAge < 20)
                    {
                        myList.Add(1);
                    }
                    else if (userAge < 30)
                    {
                        myList.Add(2);
                    }
                    else if (userAge < 40)
                    {
                        myList.Add(3);
                    }
                    else if (userAge < 50)
                    {
                        myList.Add(4);
                    }
                    else if (userAge < 60)
                    {
                        myList.Add(5);
                    }
                    else
                    {
                        myList.Add(6);
                    }
                }
            }
            Console.WriteLine("나이 입력이 완료되었습니다.");
            Console.WriteLine(string.Join(", ", myList));
            
        }
    }
}
