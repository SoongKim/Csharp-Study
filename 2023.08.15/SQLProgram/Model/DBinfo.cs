using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProgram.Model
{
    public class DBinfo
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
