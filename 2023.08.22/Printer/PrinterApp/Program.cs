﻿using SingletonPattern.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExClass exClass = new ExClass();
            exClass.Run();
        }
    }
}
