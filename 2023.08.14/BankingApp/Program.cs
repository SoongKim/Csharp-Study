using BankApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankingService bsr = new BankingService();
            bsr.Run();
        }
    }
}
