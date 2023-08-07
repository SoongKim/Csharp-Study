using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSql.Example
{
    public class Ex002_1
    {
        private readonly string currentDirectory =
            Environment.CurrentDirectory;
        public void Run()
        {
            StreamWriter sw = new StreamWriter
                (currentDirectory + @"\data\log.txt", true);
            sw.WriteLine ("프로그램 실행 시간(Ex003): {0}", DateTime.Now);
            sw.Close ();
        }
    }
}
