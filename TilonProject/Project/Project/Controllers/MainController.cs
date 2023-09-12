using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpPost("query")]
        public async Task<IActionResult> TargetQuery([FromBody] QueryModel[] queryModels)
        {
            string targetQuery = queryModels[0].queryType.ToUpper();

            if (targetQuery.Equals("SELECT"))
            {
                var result = await SelectionQuery(queryModels[0]);

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
                var result = await UpdateQuery(queryModels[0]);
                if (result is OkObjectResult okResult)
                {
                    return Ok(okResult.Value);
                }
                else
                {
                    return result;
                }
            }
            return BadRequest("Something bad happened");
        }

        #region SELECTIONQUERY PART
        [HttpPost("selectionquery")]
        public async Task<IActionResult> SelectionQuery(QueryModel queryModel)
        {
            string targetQuery = queryModel.queryType;
            string targetData = queryModel.dataFirst;
            string targetTable = queryModel.dataSecond;
            string targetCondition = queryModel.dataThird;
            string fullQuery;

            if (targetCondition.Equals("no"))
            {
                fullQuery = string.Format("{0} {1} FROM {2}", targetQuery, targetData, targetTable);
            }
            else
            {
                fullQuery = string.Format("{0} {1} FROM {2} WHERE {3}", targetQuery, targetData, targetTable, targetCondition);
            }
            dbWork dbw = new dbWork();
            return await dbw.ConnectionQuery(fullQuery);
        }
        #endregion

        #region UPDATEQUERY PART
        
        [HttpPost("updatequery")]
        public async Task<IActionResult> UpdateQuery(QueryModel queryModel)
        {
            string targetQuery = queryModel.queryType.ToUpper();
            string targetTable = queryModel.dataFirst;
            string targetColumn = queryModel.dataSecond;
            string targetValue = queryModel.dataThird;
            string targetCondition = queryModel.dataFourth;
            string fullQuery = string.Format("{0} {1} SET {2} = '{3}' WHERE {4}", targetQuery, targetTable, targetColumn, targetValue, targetCondition);
            
            dbWork dbWork = new dbWork();
            var answer = await dbWork.UpdateQuery(fullQuery);
            return Ok("수정 완료");

            //QueryModel newQueryModel = new QueryModel();
            //newQueryModel.queryType = "SELECT";
            //newQueryModel.dataFirst = "*";
            //newQueryModel.dataSecond = targetTable;
            //newQueryModel.dataThird = targetCondition;
            //newQueryModel.dataFourth = "no";
            //var newResult = await SelectionQuery(newQueryModel);
            //return newResult;
        }
        #endregion
    }
}
