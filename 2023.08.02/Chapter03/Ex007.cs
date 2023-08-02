using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex007
    {
        public void Run()
        {
            Console.WriteLine("영화 제목을 입력해주세요.");
            string titleInfo = Console.ReadLine();
            Console.WriteLine("{0} 영화의 평점을 입력해주세요.(1점 ~ 5점)", titleInfo);
            Console.WriteLine();
             try 
            {
                int scoreInfo = Convert.ToInt32(Console.ReadLine());
                if (scoreInfo == 1)
                {
                    Console.WriteLine("{0} 영화는 환불을 받고 싶을 정도로 최악의 영화군요.", titleInfo);
                }
                else if (scoreInfo == 2)
                {
                    Console.WriteLine("{0} 영화는 지루한 영화군요.", titleInfo);
                }
                else if (scoreInfo == 3)
                {
                    Console.WriteLine("{0} 영화는 시간 때우기 좋은 그 이상 그 이하도 아닌 영화군요.", titleInfo);
                }
                else if (scoreInfo == 4)
                {
                    Console.WriteLine("{0} 영화는 흥미를 유발할 만한 완성도 높은 영화군요.", titleInfo);
                }
                else if (scoreInfo == 5)
                {
                    Console.WriteLine("{0} 영화는 당신의 최고의 영화 하나로 기억되겠군요.", titleInfo);
                }
                else
                {
                    Console.WriteLine("평점 계산에 실패하였습니다.");
                }
            }
            catch { 
                Console.WriteLine("평점 계산에 실패하였습니다.");
            }
        }
    }
}
