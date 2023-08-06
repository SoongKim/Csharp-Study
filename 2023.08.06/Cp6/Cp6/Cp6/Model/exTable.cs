using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class exTable
    {
        public void Run()
        {
            Hashtable hst = new Hashtable();
            hst.Add("korea", "한국");
            hst.Add("america", "미국");
            hst.Add("britain", "영국");
            hst.Add("france", "프랑스");
            hst.Add("mexico", "멕시코");

            Console.WriteLine("단어를 입력해주세요.");
            string userInput = Console.ReadLine().ToLower();

            if(hst.Contains(userInput))
            {
                Console.WriteLine("{0} : {1}", userInput, hst[userInput]);
            }
            else
            {
                {
                    Console.WriteLine("검색 결과가 존재하지 않습니다.");
                }
            }
        }
    }
}
