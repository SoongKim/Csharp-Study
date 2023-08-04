using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples.Model;

namespace Chapter06.Examples
{
    public class PlayBall
    {
        List<WorldCup> arr = new List<WorldCup>();
        public void Run()
        {
            insertNation();

            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine("조 추첨 결과 어느 조를 조회할까요?(q:종료)");
                string targets = Console.ReadLine();
                if(targets == "q")
                {
                    break;
                }
                else
                {
                    try
                    {
                        int targetNumber = Convert.ToInt32(targets)-1;
                        printNation(targetNumber);
                    }
                    catch
                    {
                        Console.WriteLine("올바른 조 번호를 입력해주세요.");
                    }
                }
                Console.WriteLine("===========================================");
            }
            Console.ReadKey();
        }

        public void insertNation()
        {
            Console.WriteLine("몇 개 조의 정보를 입력하시겠습니까?");
            int regionCount = Convert.ToInt32(Console.ReadLine());

            for (int idx = 0; idx < regionCount; idx++)
            {
                arr.Add(new WorldCup());
                Console.WriteLine("{0}조 구성 정보를 입력합니다.", idx+1);
                Console.WriteLine("첫 번째 국가를 입력해주세요.");
                arr[idx].firstNation = Console.ReadLine();
                Console.WriteLine("두 번째 국가를 입력해주세요.");
                arr[idx].secondNation = Console.ReadLine();
                Console.WriteLine("세 번째 국가를 입력해주세요.");
                arr[idx].thirdNation = Console.ReadLine();
                Console.WriteLine("네 번째 국가를 입력해주세요.");
                arr[idx].fourthNation = Console.ReadLine();
                Console.WriteLine("============================");
                Console.WriteLine();
            }
        }

        public void printNation(int X)
        {
            Console.WriteLine("{0}조 구성 팀 정보를 출력합니다.", X);
            Console.WriteLine("1번 팀 : {0}", arr[X].firstNation);
            Console.WriteLine("2번 팀 : {0}", arr[X].secondNation);
            Console.WriteLine("3번 팀 : {0}", arr[X].thirdNation);
            Console.WriteLine("4번 팀 : {0}", arr[X].fourthNation);
        }
    }
}
