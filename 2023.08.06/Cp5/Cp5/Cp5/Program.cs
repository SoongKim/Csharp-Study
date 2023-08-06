using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cp5.Model;

namespace Cp5
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Ex001 ex001 = new Ex001();
            //ex001.Run();
            //Ex008 ex008 = new Ex008();
            //ex008.Run();
            Service.Banking ban = new Service.Banking();
            ban.Run();
        }
    }
}
