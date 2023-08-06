using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07.Model
{
    public class Ex001
    {
        public void Run()
        {
            Console.WriteLine("숫자를 입력해주세요.");
            double userSelectNum = 0;
            bool isSelected = false;
            try
            {
                userSelectNum = Convert.ToDouble(Console.ReadLine());
                isSelected = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러가 발생하였습니다.");
                Console.WriteLine(ex.HResult);
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================");
            if (isSelected)
            {
                Console.WriteLine("사용자가 선택한 숫자는 {0}", userSelectNum);
                Console.WriteLine();
                if (userSelectNum > 0)
                {
                    Console.WriteLine("양의 정수입니다.");
                }
                else if (userSelectNum == 0)
                {
                    Console.WriteLine("0입니다.");
                }
                else
                {
                    Console.WriteLine("음의 정수입니다.");
                }
            }
        }
    }
}
