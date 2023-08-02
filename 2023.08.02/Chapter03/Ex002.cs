using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditional.Examples
{
    public class Ex002
    {
        public void Run()
        {
            const int zero = 0;
            if(zero == 0){
                Console.WriteLine("첫 번째 if문입니다.");
                Console.WriteLine("zero 는 {0}이므로 출력합니다.", zero);
            }
            else
            {
                Console.WriteLine("첫 번째 else문입니다.");
                Console.WriteLine("zero != {0}일 때 출력됩니다.", zero);
            }
            if(zero == 1)
            {
                Console.WriteLine("두 번째 if문입니다.");
                Console.WriteLine("zero = 1일 때 출력됩니다.");
            }
            else
            {
                Console.WriteLine("두 번째 else문입니다.");
                Console.WriteLine("zero != 1일 때 출력됩니다.");
            }
        }
    }
}
