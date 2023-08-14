using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda.Example
{
    internal class Ex001
    {
        internal void Run()
        {
            int[] number = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // 10칸 배열. 초기화 값이 산입됨
            List<int> tmpNumber = new List<int>();
            // 정수형(int) 데이터만 입력 가능한 List 선언

            //람다식으로 짝수, 홀수 탐색하고 출력하기
            Console.WriteLine("짝수를 출력합니다.");
            number.Where(n => (n % 2) == 0).OrderBy(n => n).ToList()
                .ForEach(n => Console.WriteLine(n));
            Console.WriteLine();
            Console.WriteLine("홀수를 출력합니다.");
            number.Where(n => (n % 2) == 1).OrderBy(n => n).ToList()
                .ForEach(n => Console.WriteLine(n));
            Console.ReadKey();
        }
    }
}
