using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Globalization;

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
                var result = await SelectionQuery(jsonQueryModel[0]);

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
                var result = await UpdateQuery(jsonQueryModel[0]);
                /* Json 내 Value값이 필요한 경우가 아니므로 return result;로 간략화 */
                return result;
            }
            else if (targetQuery.Equals("INSERT"))
            {
                var result = await InsertQuery(jsonQueryModel[0]);
                return result;
            }
            else if (targetQuery.Equals("DELETE"))
            {
                var result = await DeleteQuery(jsonQueryModel[0]);
                return result;
            }

            return BadRequest("입력하신 쿼리절이 올바르지 않습니다.");
        }
        #endregion

        #region SELECTIONQUERY PART
        [HttpPost("selectionquery")]
        public async Task<IActionResult> SelectionQuery(QueryModel queryModel)
        {
            
            string fullQuery;
            if (queryModel.dataThird == null)
            {
                fullQuery = string.Format("{0} {1} FROM {2}", queryModel.queryType, queryModel.dataFirst, queryModel.dataSecond);
            }
            else
            {
                fullQuery = string.Format("{0} {1} FROM {2} WHERE {3}", queryModel.queryType, queryModel.dataFirst, queryModel.dataSecond, queryModel.dataThird);
            }
            dbWork dbw = new dbWork();
            return await dbw.SelectQuery(fullQuery);
        }
        #endregion

        #region UPDATEQUERY PART

        [HttpPost("updatequery")]
        public async Task<IActionResult> UpdateQuery(QueryModel querymodel)
        {
            string fullQuery = string.Format("{0} {1} SET {2} = '{3}' WHERE {4};", 
                querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, querymodel.dataThird, querymodel.dataFourth);

            var result = await toDBcontroller(fullQuery);
            return result;
            #region 변경사항 조회(현재 미사용)
            //QueryModel newqueryModel = new QueryModel();
            //newqueryModel.queryType = "select";
            //newqueryModel.dataFirst = "*";
            //newqueryModel.dataSecond = targetTable;
            //newqueryModel.dataThird = targetCondition;
            //newqueryModel.dataFourth = "no";
            //var newresult = await SelectionQuery(newqueryModel);
            //return newresult;
            #endregion
        }
        #endregion

        #region INSERT QUERY(Normal) PART
        [HttpPost("insertquery")]
        public async Task<IActionResult> InsertQuery(QueryModel querymodel)
        {
            string[] colArr = querymodel.dataSecond.Split(", ");
            string[] valArr = querymodel.dataThird.Split(", ");
            
            if(colArr.Length != valArr.Length)
            {
                return BadRequest("입력하는 컬럼과 값의 갯수가 일치하지 않습니다.");
            }

            /* INSERT 간 다중 컬럼을 대상으로 입력을 요할 시. 형식에 맞춰 데이터를 정돈한다. */
            for(int i = 0; i < valArr.Length; i++)
            {
                if(i != valArr.Length - 1)
                {
                    valArr[i] = "'" + valArr[i] + "', ";
                }
                else
                {
                    valArr[i] = "'" + valArr[i] + "'";
                }
            }

            string newTargetValue = "";
            for(int i = 0; i < colArr.Length; i++)
            {
                newTargetValue += valArr[i];
            }

            string fullQuery = string.Format("{0} INTO {1} ({2}) VALUES ({3});", querymodel.queryType.ToUpper(), querymodel.dataFirst, querymodel.dataSecond, newTargetValue);

            //return Ok(fullQuery);
            var result = await toDBcontroller(fullQuery);
            return result;
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
            string member_id = "'" + uiM[0].member_id+"', ";
            string password = "'"+uiM[0].password+"', ";
            string email = "'"+uiM[0].email+"', ";
            string name = "'"+uiM[0].name+"', ";
            string gender = "'"+uiM[0].gender+"', ";
            string birthday = string.Format("DATE_FORMAT('{0}', '%Y-%m-%d'), ", uiM[0].birthday);
            string phone = "'"+uiM[0].phone+"', ";
            string role_id = "'"+uiM[0].role_id+"'";

            //return Ok("Good2");

            string fullTarget = member_id + password + email + name + gender + birthday + phone + role_id;

            //return Ok("Good3");
            
            string fullQuery = string.Format("INSERT INTO member " +
                "(member_id, password, email, name, gender, birthday, phone, role_id) " +
                "VALUES ({0})", fullTarget);

            //return Ok(fullQuery);

            dbWork dbWorks = new dbWork();
            var result = await dbWorks.UpdateInsertDeleteQuery(fullQuery);
            
            if (result is OkObjectResult okResult)
            {
                return Ok(okResult.Value);
            }
            else
            {
                return result;
            }
        }
        #endregion

        [HttpPost("Delete Query")]
        public async Task<IActionResult> DeleteQuery(QueryModel querymodel)
        {
            string fullQuery = string.Format("DELETE FROM {0} WHERE {1} = {2}", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond);
            var result = await toDBcontroller(fullQuery);
            return result;
        }

        [HttpPost("toDBconnector")]
        public async Task<IActionResult> toDBcontroller(string targetQuery)
        {
            dbWork dbWorks = new dbWork();
            var result = await dbWorks.UpdateInsertDeleteQuery(targetQuery);
            if(result is OkObjectResult okResult)
            {
                return Ok(okResult.Value);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
