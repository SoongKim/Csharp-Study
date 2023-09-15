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
        [HttpPost("string")]
        public async Task<IActionResult> stringResponse([FromBody] Hello hello)
        {
            return Ok(hello.mrString);
        }
        
        
        #region INSERT(Normal), SELECT, UPDATE
        [HttpPost("query")]
        public async Task<IActionResult> TargetQuery([FromBody] QueryModel jsonQueryModel)
        {
            string targetQuery = jsonQueryModel.queryType.ToUpper();
            try
            {
                if (targetQuery.Equals("SELECT"))
                {
                    QueryServices queryservices = new QueryServices();
                    if (jsonQueryModel.dataThird != null)
                    {
                        string answer = queryservices.SqlInjectionChecking(jsonQueryModel.dataThird);
                        if (answer.Equals("CODE001"))
                        {
                            return BadRequest("SQL INJECTION 공격이 감지되었습니다.");
                        }
                    }
                    var result = await queryservices.Select(jsonQueryModel);
                    /* result 내 Value 값만을 정제하여 return */
                    if (result is OkObjectResult okResult)
                    {
                        return Ok(okResult.Value);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else if (targetQuery.Equals("UPDATE"))
                {
                    QueryServices queryservices = new QueryServices();
                    if (jsonQueryModel.dataFourth != null)
                    {
                        string answer = queryservices.SqlInjectionChecking(jsonQueryModel.dataFourth);
                        if (answer.Equals("CODE001"))
                        {
                            return BadRequest("SQL INJECTION 공격이 감지되었습니다.");
                        }
                    }
                    var result = await queryservices.Update(jsonQueryModel);
                    /* Json 내 Value값이 필요한 경우가 아니므로 return result;로 간략화 */
                    return result;
                }
                else if (targetQuery.Equals("INSERT"))
                {
                    QueryServices queryservices = new QueryServices();
                    if (jsonQueryModel.dataFourth != null)
                    {
                        string answer = queryservices.SqlInjectionChecking(jsonQueryModel.dataFourth);
                        if (answer.Equals("CODE001"))
                        {
                            return BadRequest("SQL INJECTION 공격이 감지되었습니다.");
                        }
                    }
                    var result = await queryservices.Insert(jsonQueryModel);
                    return result;
                }
                else if (targetQuery.Equals("DELETE"))
                {
                    QueryServices queryservices = new QueryServices();
                    if (jsonQueryModel.dataSecond != null)
                    {
                        string answer = queryservices.SqlInjectionChecking(jsonQueryModel.dataSecond);
                        if (answer.Equals("CODE001"))
                        {
                            return BadRequest("SQL INJECTION 공격이 감지되었습니다.");
                        }
                    }

                    var result = await queryservices.Delete(jsonQueryModel);
                    return result;
                }

            }
            catch(Exception ex){
                return BadRequest(ex.Message);
                /* 어떤 오류가 발생하였는지 에러 코드 + 어떤 부분이 잘못되었는지 에러 코드 뱉도록 */
            }
            return BadRequest("Error Occured!");
        }
        #endregion

        #region INSERT QUERY(User) PART
        [HttpPost("userInsert")]
        public async Task<IActionResult> userInfoController([FromBody] UserInfoModel uiM)
        {
            #region BadRequest 판정 부문
            if (uiM == null)
            {
                return BadRequest("Json Body에 값이 담기지 않았습니다.");
            }
            if (!uiM.gender.Equals("Male") && !uiM.gender.Equals("Female"))
            {
                return BadRequest("성별 항목에 적합하지 못한 값이 입력되었습니다.");
            }
            if (uiM.role_id.Equals("0"))
            {
                return BadRequest("신규 관리자 생성은 DataBase에서 수행하여주시기 바랍니다.");
            }
            #endregion

            //return Ok("Good1");

            /* 데이터 정제 부문 */
            string user_id = "'" + uiM.user_id + "', ";
            string password = "'" + uiM.password + "', ";
            string email = "'" + uiM.email + "', ";
            string name = "'" + uiM.name + "', ";
            string gender = "'" + uiM.gender + "', ";
            string birthday = string.Format("DATE_FORMAT('{0}', '%Y-%m-%d'), ", uiM.birthday);
            string phone = "'" + uiM.phone + "', ";
            string role_id = "'" + uiM.role_id + "'";

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
