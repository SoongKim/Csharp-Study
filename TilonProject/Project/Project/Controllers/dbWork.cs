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
        public async Task<IActionResult> SelectQuery(string fullQuery) /* Host/api/main/query 에서 도출한 fullQuery를 매개 변수로 진행 */
        {
            try
            {
                string connStr = Environment.GetEnvironmentVariable("DB_CONNECTION_INFO");
                using (MySqlConnection connection = new MySqlConnection(connStr))
                {
                    await connection.OpenAsync();

                    /* 쿼리문, 연결 정보를 바탕으로 명령 수행 */
                    MySqlCommand cmd = new MySqlCommand(fullQuery, connection); 
                    /* 해당 dbResult List에 DB로부터 데이터를 받아와 저장한다. */
                    List<string> dbResult = new List<string>();
                    using (MySqlDataReader msr = (MySqlDataReader)await cmd.ExecuteReaderAsync())
                    {
                        /* 모든 데이터를 불러올 때까지 필드 카운트 수만큼 List에 데이터 적재 */
                        while (await msr.ReadAsync())
                        {
                            for (int i = 0; i < msr.FieldCount; i++)
                            {
                                dbResult.Add(msr.GetString(i));
                            }
                        }
                    }
                    /* OK 시 해당 List를 Response한다. */
                    return Ok(dbResult);
                }
            }
            /* DB Connection 오류, Query문 오류 등 모든 에러 사건 발생 시 메시지 문구를 출력하는 BadRequest 발생. */
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
    }
}
