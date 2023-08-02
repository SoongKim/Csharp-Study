using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Understand02
    {
        public void Run()
        {
            try
            {
            #region >> 변수선언절
            Console.WriteLine("중간고사 점수를 입력해주세요.");
                int midScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("기말고사 점수를 입력해주세요.");
                int lastScore = Convert.ToInt32(Console.ReadLine());
            double avgScore = (double)(midScore + lastScore) / 2;
            #endregion
            #region >> 조건문 절
            if (avgScore >= 90)
                {
                    Console.WriteLine("평균 점수는 {0}이며, 수취 학점은 A 입니다.", avgScore);
                }
            else if(avgScore >= 80)
                {
                    Console.WriteLine("평균 점수는 {0}이며, 수취 학점은 B 입니다.", avgScore);
                }
            else
                {
                    Console.WriteLine("평균 점수는 {0}이며, 수취 학점은 C입니다.", avgScore);
                }
            }
            catch
            {
                Console.WriteLine("잘못된 점수를 입력하셨습니다.");
            }
            #endregion
        }
    }
}
