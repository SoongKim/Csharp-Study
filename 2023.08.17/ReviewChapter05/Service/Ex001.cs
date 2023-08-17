using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewChapter05.Service
{
    public class Ex001
    {
        private readonly string dirInfo = Environment.CurrentDirectory;
        public void Run()
        {
            DirectoryInfo drInfo = new DirectoryInfo(dirInfo+@"data");
            if(!drInfo.Exists)
            {
                drInfo.Create();
            }
            using(StreamWriter sw = 
                new StreamWriter(dirInfo+@"\data\log.txt", true))
            {
                Dictionary<string, string> myDict = new Dictionary<string, string>();
                myDict.Add("string", "straight");
                myDict.ToArray();
                sw.WriteLine(myDict["string"]);
                sw.WriteLine(myDict["straight"]);
            }
        }
    }
}
