using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex011
    {
        public void Run()
        {
            // Hashtable : 딕셔너리와 유사한 개념으로 이해했다.
            // key : value 구조를 지니며, key 호출 시 value가 불러져온다.
            #region >> Hash table
            Hashtable hst = new Hashtable();
            hst.Add("Korea", "한국");
            hst.Add("Japan", "일본");
            hst.Add("America", "미국");
            hst.Add("Brazil", "브라질");
            hst.Add("Spain", "스페인");
            hst.Add("Britain", "영국");
            hst.Add("France", "프랑스");

            Console.WriteLine("단어를 입력하세요 : ");
            string userWord = Console.ReadLine();

            if(hst.Contains(userWord))
            {
                Console.WriteLine("{0} : {1}", userWord, hst[userWord]);
            }
            else
            {
                Console.WriteLine("단어 검색 결과가 존재하지 않습니다.");
            }

            #endregion
        }
    }
}
