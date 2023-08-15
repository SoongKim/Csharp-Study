using DashBoard.Example.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.Example.Manager
{
    public interface IDatabaseManager
    {
        void Open(DatabaseInfo dbInfo);
        DataTable Select(string Sql);
        int Insert(string sql);
        int Update(string sql);
        int Delete(string sql);
        void Close();
    }
}
