using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex001
    {
        public void Run()
        {
            // 조건절 - if문
            const int zero = 0;
            if(zero == 0)
            {
                Console.WriteLine("첫 번째 if문입니다.");
                Console.WriteLine();
            }
            if(zero == 0)
            {
                Console.WriteLine("두 번째 if문입니다.");
                Console.WriteLine("zero = {0} 이므로 출력되었습니다.", zero);
                Console.WriteLine();
            }
            if(zero == 1)
            {
                Console.WriteLine("세 번째 if문입니다.");
                Console.WriteLine("zero = 1일 때 출력됩니다.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("네 번재 if문입니다.");
                Console.WriteLine("zero != 1일 때 출력됩니다.");
            }
        }
    }
}
