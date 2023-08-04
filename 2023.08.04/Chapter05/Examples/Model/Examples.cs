using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBasic.Chapter05.Examples.Model
{
    public class Examples
    {
        int firstNum;
        int secondNum;

        public void Run()
        {
            Console.WriteLine("정수를 입력해주세요.");
            this.firstNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("두 번째 정수를 입력해주세요.");
            this.secondNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("{0}과 {1}이 입력되었습니다.",
                this.firstNum, this.secondNum);

            Chapter05.Examples.Service.Calculate cal = new Service.Calculate();
            for (int i = 0; i < 999999; i++)
            {
                Console.WriteLine("원하시는 연산 부호를 입력해주세요.");
                Console.WriteLine("[ + - * / ]");
                string userSelect = Console.ReadLine();

                try
                {
                    switch (userSelect)
                    {
                        case "+":
                            {
                                Console.WriteLine("더하기 연산 결과 : {0},",
                                    cal.Sumation(this.firstNum, this.secondNum));
                                break;
                            }
                        case "-":
                            {
                                Console.WriteLine("빼기 연산 결과 : {0},",
                                    cal.Minus(this.firstNum, this.secondNum));
                                break;
                            }
                        case "*":
                            {
                                Console.WriteLine("곱하기 연산 결과 : {0},",
                                    cal.Multiple(this.firstNum, this.secondNum));
                                break;
                            }
                        case "/":
                            {
                                Console.WriteLine("나누기 연산 결과 : {0},",
                                    cal.Divide(this.firstNum, this.secondNum));
                                break;
                            }
                    }
                }
                catch
                {
                    Console.WriteLine("올바른 기호를 입력해주세요.");
                }

            }



        }
    }

}