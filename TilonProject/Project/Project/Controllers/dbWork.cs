using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Hosting.Server;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dbWork : ControllerBase
    {
        #region SELECT QUERY
        /* swagger 포인트 잡기 위한 Post타입 요청 설계 */
        [HttpPost("SelectQuery")]
        public async Task<IActionResult> SelectQuery(string fullQuery)
        {
            try
            {
                string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_INFO");
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    await connection.OpenAsync();

                    MySqlCommand cmd = new MySqlCommand(fullQuery, connection);
                    List<Dictionary<string, object?>> dbResult = new List<Dictionary<string, object?>>();
                    using (MySqlDataReader msr = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        while (await msr.ReadAsync())
                        {
                            Dictionary<string, object?> row = new Dictionary<string, object?>();
                            for (int i = 0; i < msr.FieldCount; i++)
                            {
                                string columnName = msr.GetName(i);
                                object value = msr[i];
                                row[columnName] = value;
                            }
                            dbResult.Add(row);
                        }
                    }
                    return Ok(dbResult);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region UPDATE, INSERT, DELETE QUERY
        [HttpPost("UpdateInsertDelete")]
        public async Task<IActionResult> UpdateInsertDeleteQuery(string fullQuery)
        {
            try
            {
                string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_INFO");
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    await connection.OpenAsync();

                    using(MySqlCommand cmd = new MySqlCommand(fullQuery, connection))
                    {
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            return Ok("처리되었습니다.");
                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost("LogSession")]
        public async Task<IActionResult> LogSession(string? logUser, string queryType, string userType)
        {
            string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_INFO");
            string fullQuery;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                await connection.OpenAsync();

                if (userType.Equals("0") && logUser == null)
                {
                    fullQuery = string.Format("INSERT INTO log (admin_id, action) values ('{0}', '{1}');", "Admin", queryType+" total User Infoes");
                }
                else if (userType.Equals("0") && logUser != null)
                {
                    fullQuery = string.Format("INSERT INTO log (admin_id, action) values ('{0}', '{1}');", "Admin", queryType + " specific User " + "[" +logUser+ "]" + " Infoes");
                }
                else if(userType.Equals("1") && logUser != null)
                {
                    fullQuery = string.Format("INSERT INTO log (user_id, action) values ('{0}', '{1}');", logUser, queryType+" user Own Infoes");
                }
                else
                {
                    return BadRequest("Normal User Doesn't Authorized to Search Total User Infoes");
                }

                using (MySqlCommand cmd = new MySqlCommand(fullQuery, connection))
                {
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Affected Row Count is 0");
                    }
                }
            }
        }
    }
}
