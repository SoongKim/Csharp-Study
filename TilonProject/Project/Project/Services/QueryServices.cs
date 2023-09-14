using Microsoft.AspNetCore.Mvc;
using Project.Controllers;
using Project.Models;

namespace Project.Services
{
    public class QueryServices
    {
        #region SELECT QUERY PART
        public async Task<IActionResult> Select(QueryModel queryModel)
        {
            string fullQuery;
            if (queryModel.dataThird == null)
            {
                fullQuery = string.Format("{0} {1} FROM {2};", queryModel.queryType, queryModel.dataFirst, queryModel.dataSecond);
            }
            else
            {
                fullQuery = string.Format("{0} {1} FROM {2} WHERE {3};", queryModel.queryType, queryModel.dataFirst, queryModel.dataSecond, queryModel.dataThird);
            }
            dbWork dbw = new dbWork();
            return await dbw.SelectQuery(fullQuery);
        }
        #endregion

        #region INSERT QUERY(Normal) PART
        public async Task<IActionResult> Insert(QueryModel querymodel)
        {
            string fullQuery = "";
            if (querymodel.dataSecond.Contains(","))
            {
                string[] colArr = querymodel.dataSecond.Split(", ");
                string[] valArr = querymodel.dataThird.Split(", ");

                //if (colArr.Length != valArr.Length)
                //{
                //    return BadRequest("입력하는 컬럼과 값의 갯수가 일치하지 않습니다.");
                //}

                /* INSERT 간 다중 컬럼을 대상으로 입력을 요할 시. 형식에 맞춰 데이터를 정돈한다. */
                for (int i = 0; i < valArr.Length; i++)
                {
                    if (i != valArr.Length - 1)
                    {
                        valArr[i] = "'" + valArr[i] + "', ";
                    }
                    else
                    {
                        valArr[i] = "'" + valArr[i] + "'";
                    }
                }

                string newTargetValue = "";
                for (int i = 0; i < colArr.Length; i++)
                {
                    newTargetValue += valArr[i];
                }
                if (querymodel.dataFourth == null)
                {
                    fullQuery = string.Format("{0} INTO {1} ({2}) VALUES ({3});", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, newTargetValue);
                }
                else
                {
                    fullQuery = string.Format("{0} INTO {1} ({2}) VALUES ({3}) WHERE {4};", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, newTargetValue, querymodel.dataFourth);
                }

            }
            else
            {
                if (querymodel.dataFourth == null)
                {
                    fullQuery = string.Format("{0} INTO {1} ({2}) VALUES ('{3}');", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, querymodel.dataThird);
                }
                else
                {
                    fullQuery = string.Format("{0} INTO {1} ({2}) VALUES ('{3}') WHERE {4};", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, querymodel.dataThird, querymodel.dataFourth);
                }
            }
            //return Ok(fullQuery);
            MainController maincontroller = new MainController();
            var result = await maincontroller.toDBcontroller(fullQuery);
            return result;
        }
        #endregion

        #region UPDATEQUERY PART
        public async Task<IActionResult> Update(QueryModel querymodel)
        {
            string fullQuery = string.Format("{0} {1} SET {2} = '{3}' WHERE {4};",
                querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond, querymodel.dataThird, querymodel.dataFourth);

            MainController maincontroller = new MainController();
            return await maincontroller.toDBcontroller(fullQuery);
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

        #region DELETE QUERY PART
        public async Task<IActionResult> Delete(QueryModel querymodel)
        {
            MainController maincontroller = new MainController();
            string fullQuery = string.Format("{0} FROM {1} WHERE {2};", querymodel.queryType, querymodel.dataFirst, querymodel.dataSecond);
            return await maincontroller.toDBcontroller(fullQuery);
        }
        #endregion
        
    }
}
