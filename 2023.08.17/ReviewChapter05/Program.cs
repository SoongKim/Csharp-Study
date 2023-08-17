using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewChapter05.Service;

namespace ReviewChapter05
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankingService bs = new BankingService();
            bs.Run();
            //Ex001 ex001 = new Ex001();
            //ex001.Run();
        }
    }
}
