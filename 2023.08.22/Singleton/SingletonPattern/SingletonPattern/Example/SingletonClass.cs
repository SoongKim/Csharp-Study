using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern.Example
{
    public class SingletonClass
    {
        private static SingletonClass sCt = new SingletonClass();
        private SingletonClass() { }
        public static SingletonClass getInstance()
        {
            return sCt;
        }
        private static Boolean isUse = false;

        public static void drive()
        {
            isUse = true;
            Console.WriteLine("start driving");
        }
        public static void parking()
        {
            isUse = false;
            Console.WriteLine("parking now");
        }
    }
}
