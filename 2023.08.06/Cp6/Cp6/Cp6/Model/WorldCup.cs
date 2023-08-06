using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class WorldCup
    {
        public void Run()
        {
            Dictionary<string, List<string>> wcGroup = new Dictionary<string, List<string>>();
            
            List<string> groupA = new List<string>();
            groupA.Add("대한민국");
            groupA.Add("프랑스");
            groupA.Add("미국");
            groupA.Add("이집트");

            List<string> groupH = new List<string>();
            groupH.Add("일본");
            groupH.Add("브라질");
            groupH.Add("독일");
            groupH.Add("스페인");

            wcGroup.Add("A", groupA);
            wcGroup.Add("H", groupH);

            while (true)
            {
                Console.Write("조 추첨 결과 어느 조를 조회할까요?(q: 종료)");
                string searchingGroup = Console.ReadLine();
                if(searchingGroup =="q") 
                {
                    break;
                }
                if(wcGroup.ContainsKey(searchingGroup))
                {
                    Console.WriteLine("{0} 조에 속한 나라는", searchingGroup);
                    Console.WriteLine(wcGroup[searchingGroup][0]);
                    Console.WriteLine(wcGroup[searchingGroup][1]);
                    Console.WriteLine(wcGroup[searchingGroup][2]);
                    Console.WriteLine(wcGroup[searchingGroup][3]);
                    Console.WriteLine("입니다.");
                }
                else
                {
                    Console.WriteLine("입력하신 조 정보가 없습니다.");
                }
            }

        }
    }
}
