using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Globalization;
using Project.Services;
namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        #region INSERT(Normal), SELECT, UPDATE
        [HttpPost("query")]
        public async Task<IActionResult> TargetQuery([FromBody] QueryModel[] jsonQueryModel)
        {
            string targetQuery = jsonQueryModel[0].queryType.ToUpper();
            if (targetQuery.Equals("SELECT"))
            {
                QueryServices queryservices = new QueryServices();
                var result = await queryservices.Select(jsonQueryModel[0]);
                /* result 내 Value 값만을 정제하여 return */
                if (result is OkObjectResult okResult)
                {
                    return Ok(okResult.Value);
                }
                else
                {
                    return result;
                }
            }
            else if (targetQuery.Equals("UPDATE"))
            {
                QueryServices queryservices = new QueryServices();
                var result = await queryservices.Update(jsonQueryModel[0]);
                /* Json 내 Value값이 필요한 경우가 아니므로 return result;로 간략화 */
                return result;
            }
            else if (targetQuery.Equals("INSERT"))
            {
                QueryServices queryservices = new QueryServices();
                var result = await queryservices.Insert(jsonQueryModel[0]);
                return result;
            }
            else if (targetQuery.Equals("DELETE"))
            {
                QueryServices queryservices = new QueryServices();
                var result = await queryservices.Delete(jsonQueryModel[0]);
                return result;
            }
            return BadRequest("입력하신 쿼리절이 올바르지 않습니다.");
        }
        #endregion

        #region INSERT QUERY(User) PART
        [HttpPost("userInsert")]
        public async Task<IActionResult> userInfoController([FromBody] UserInfoModel[] uiM)
        {
            #region BadRequest 판정 부문
            if (uiM == null)
            {
                return BadRequest("Json Body에 값이 담기지 않았습니다.");
            }
            if (!uiM[0].gender.Equals("Male") && !uiM[0].gender.Equals("Female"))
            {
                return BadRequest("성별 항목에 적합하지 못한 값이 입력되었습니다.");
            }
            #endregion

            //return Ok("Good1");

            /* 데이터 정제 부문 */
            string user_id = "'" + uiM[0].user_id + "', ";
            string password = "'" + uiM[0].password + "', ";
            string email = "'" + uiM[0].email + "', ";
            string name = "'" + uiM[0].name + "', ";
            string gender = "'" + uiM[0].gender + "', ";
            string birthday = string.Format("DATE_FORMAT('{0}', '%Y-%m-%d'), ", uiM[0].birthday);
            string phone = "'" + uiM[0].phone + "', ";
            string role_id = "'" + uiM[0].role_id + "'";

            //return Ok("Good2");

            string fullTarget = user_id + password + email + name + gender + birthday + phone + role_id;

            //return Ok("Good3");

            string fullQuery = string.Format("INSERT INTO user_id (user_id, password, email, name, gender, birthday, phone, role_id) VALUES ({0});", fullTarget);

            //return Ok(fullQuery);

            dbWork dbWorks = new dbWork();
            return await dbWorks.UpdateInsertDeleteQuery(fullQuery);
        }
        #endregion

        #region DBCONNECTING
        [HttpPost("toDBconnector")]
        public async Task<IActionResult> toDBcontroller(string targetQuery)
        {
            dbWork dbWorks = new dbWork();
            var result = await dbWorks.UpdateInsertDeleteQuery(targetQuery);
            if (result is OkObjectResult okResult)
            {
                return Ok(okResult.Value);
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
