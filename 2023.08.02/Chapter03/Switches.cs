using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Switches
    {
        public void Run()
        {
            #region >> Switch 문을 사용하는 경우
            // 보통, 조건절 코드 작성 간 메인이 되는 방법은 if문
            // 그러나, 조건 판단 기준식이 일반 상수와의 비교라면, switch 문을 사용하는 것이 더 편하다.
            // if문은 여러 조건의 조합과 수에 대한 크기 비교 등 조건문이 복잡한 구조를 지닐수록 더 효율적이다. 
            #endregion
            Console.WriteLine("최근 관람하신 영화의 제목을 입력해주세요.");
            string titleInfo = Console.ReadLine();
            Console.WriteLine("{0} 영화의 관람 평점을 입력해주세요.", titleInfo);
            try
            {
                int scoreInfo = Convert.ToInt32(Console.ReadLine());
                switch (scoreInfo)
                {
                    case 1:
                        Console.WriteLine("{0} 영화는 환불을 부르는 영화군!", titleInfo);
                        break;
                    case 2:
                        Console.WriteLine("{0} 영화는 지루한 영화군!", titleInfo);
                        break;
                    case 3:
                        Console.WriteLine("{0} 영화는 킬링 타임용 영화군!", titleInfo);
                        break;
                    case 4:
                        Console.WriteLine("{0} 영화는 짜임새 있는 영화군!", titleInfo);
                        break;
                    case 5:
                        Console.WriteLine("{0} 영화는 최고의 영화 중 하나군!", titleInfo);
                        break;
                    default:
                        Console.WriteLine("평점 계산에 실패하였습니다.");
                        break;
                }
            }
            catch {
                Console.WriteLine("평점 계산에 실패하였습니다.");
            }
        }
    }
}
