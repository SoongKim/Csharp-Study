using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp6.Model
{
    public class Pedia
    {
        public void Run()
        {
            Hashtable hst = new Hashtable();
            Boolean isValid = true;
            while (isValid)
            {
                Console.WriteLine("======= 단어를 입력해주세요. =======");
                Console.WriteLine("q: 종료");
                string targetWord = Console.ReadLine().ToLower();
                if(targetWord == "q")
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    break;
                }
                
                if (hst.Contains(targetWord))
                {
                    Console.WriteLine("{0} : {1}", targetWord, hst[targetWord]);
                    Console.WriteLine("해당 단어와 뜻을 삭제할까요?");
                    Console.WriteLine("y: 네 / n ; 아니오");
                    string userSelect = Console.ReadLine().ToLower();
                    if(userSelect == "y")
                    {
                        Console.WriteLine("{0} : {1} 이/가 삭제되었습니다.", targetWord, hst[targetWord]);
                        hst.Remove(targetWord);
                    }
                }
                else
                {
                    Console.WriteLine("검색 결과가 존재하지 않습니다. {0}을 추가할까요?", targetWord);
                    Console.WriteLine("y: 네 / n : 아니오");
                    string userChoice = "";
                    Boolean validData = true;
                    try
                    {
                        userChoice = Console.ReadLine().ToLower();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("오류가 발생하였습니다.");
                        Console.WriteLine(e.HResult);
                        Console.WriteLine(e.Message);
                        validData = false;
                    }
                    if (validData && userChoice == "y")
                    {
                        Console.WriteLine("{0}의 뜻을 입력해주세요.", targetWord);
                        string wordMeaning = Console.ReadLine();
                        hst.Add(targetWord, wordMeaning);
                        Console.WriteLine("{0} : {1} 이/가 입력되었습니다.", targetWord, wordMeaning);
                    }
                    else
                    {
                        Console.WriteLine("메인 화면으로 돌아갑니다.");
                    }
                }
                Console.WriteLine("====================================");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
