using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex013
    {
        public void Run()
        {
            ArrayList aList = new ArrayList();
            aList.Add("a");
            aList.Add("b");
            aList.Add("c");
            aList.Add("d");
            aList.Add("e");
            for(int idx = 0; idx < aList.Count; idx++)
            {
                Console.WriteLine(aList[idx].ToString().ToUpper());
            }
        }
        // Boxing : 기타 데이터 타입들을 Object 타입으로 바꾸는 것
        // Unboxing : Object 타입을 실제 값 타입으로 바꾸는 것
    }
}
