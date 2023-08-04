using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LottoCalc.Service;

namespace LottoCalc.Model
{
    public class Moduler
    {
        public void Run()
        {
            Console.WriteLine("몇 게임 플레이할까요?");
            int count = 0;
            try
            {
                int wheelNum = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < wheelNum; i++)
                {
                    Lottery lts = new Lottery();
                    Console.WriteLine("{0}회차", i + 1);
                    Console.WriteLine(string.Join(", ", lts.findNumber()));
                    Console.WriteLine("=====================");
                    count++;
                }
            }
            catch
            {
                Console.WriteLine("올바른 정수로 플레이 횟수를 기입해주세요.");
            }
            Console.WriteLine();
            Console.WriteLine("플레이가 종료되었습니다.");
            Console.WriteLine("총 {0}원 결제가 필요합니다.", count * 1000);
            Console.ReadKey();
        }
    }
}
