using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForSql.Example
{
    public class Ex002
    {
        private readonly string currentDirectory =
            Environment.CurrentDirectory;
        public void Run()
        {
            // using을 사용하면 Close 구문 안 써도 OK!
            using (StreamWriter sw = new StreamWriter
                (currentDirectory + @"\data\log.txt", true))
            {
                sw.WriteLine("프로그램 실행 시간(Ex002): {0}", DateTime.Now);
            } 
        }
        #region
        // Ex002와 Ex002_1은 완전히 동일한 기능을 수행한다!
        #endregion
    }
}
