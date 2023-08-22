using PrinterApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service();
            service.Run();
            Console.ReadKey();
        }
    }
}
