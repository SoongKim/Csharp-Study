using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.Example;
using DashBoard.Example.Model;
using DashBoard.Example.Manager;

namespace DashBoard.Example.Service
{
    public class  MsSqlManager : IDatabaseManager
    {
        SqlConnection connection = null;
        public void Open(DatabaseInfo dbInfo)
        {
            string conStr = string.Format(
                "DataSource={0},{1};InitialCatalog={2};" +
                "UserID={3};Password={4}",
                dbInfo.Ip,dbInfo.Port,dbInfo.Name,dbInfo.UserId,dbInfo.UserPassword);
            connection = new SqlConnection(conStr);
            connection.Open();
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    for(int idx = 0; idx < reader.FieldCount; idx++)
                    {
                        dt.Columns.Add(new DataColumn(reader.GetName(idx)));
                    }
                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        for(int idx = 0; idx < dt.Columns.Count; idx++)
                        {
                            row[dt.Columns[idx]] =
                                reader[dt.Columns[idx].ColumnName];
                        }
                        dt.Rows.Add(row);
                    }
                }
            }
            
            return dt;
        }
        public int Insert(string sql)
        {
            int activeNumber = 0;
            using(SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }
        public int Update(string sql)
        {
            int activeNumber = 0;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }
        public int Delete(string sql)
        {
            int activeNumber = 0;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }
        public void Close()
        {
            if(connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}