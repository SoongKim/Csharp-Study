using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex012
    {
        public void Run()
        {
            Hashtable hst = new Hashtable();
            hst.Add("korea", "한국");
            hst.Add("japan", "일본");
            hst.Add("america", "미국");
            hst.Add("canada", "캐나다");
            hst.Add("britain", "영국");
            hst.Add("spain", "스페인");

            while (true)
            {
                Console.Write("단어를 입력하세요(Q:종료) : ");
                string word = Console.ReadLine().ToLower();
                if (word == "q")
                {
                    break;
                }

                if (hst.Contains(word))
                {
                    Console.WriteLine("{0} : {1}", word, hst[word]);
                    Console.WriteLine("단어를 삭제할까요?(Y : 삭제 / N : 미삭제");
                    string userSelect = Console.ReadLine();
                    if (userSelect == "Y")
                    {
                        hst.Remove(word);
                    }
                }
                else
                {
                    Console.WriteLine("단어 검색 결과가 없습니다. " +
                        "사전에 추가할까요?");
                    Console.WriteLine("Y : 추가 / N : 미추가)");
                    string addWord = Console.ReadLine().ToLower();
                    if (addWord == "y")
                    {
                        Console.WriteLine("뜻을 입력하세요.");
                        string addWord2 = Console.ReadLine();
                        
                        hst.Add(addWord, addWord2);
                    }
                }
            }

        }
    }
}
