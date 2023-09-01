using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvUpload.Controllers
{
    [ApiController]
    [Route("api")]
    /* 기본 연결 루트는 IP:Port/api */
    /* 전번 과제에서 사용하였던 ASP.NET Core 웹앱(MVC) 프로젝트에 해당 Api 컨트롤러만을 추가로 증설하였습니다. */
    
    public class CsvController : ControllerBase
    {
        /* get, set 자동 생성
         * customerdata.csv의 ColumnName 인 BA, ST, LA를 세팅한다.
         */
        public class CsvInfoes
        {
            public string BA { get; set; }
            public string ST { get; set; }
            public string LA { get; set; }
        }

        /* Request 경로 : Post 타입으로, https://localhost:7251/api/csvUp */
        [HttpPost("csvUp")]
        public async Task<IActionResult> CsvUpload()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                /* StreamReader를 사용하여 Request의 body에 담긴 데이터를 읽어옵니다. */

                    for (int i = 0; i < 4; i++)
                    {
                        await reader.ReadLineAsync();
                    }
                    /* form-data 형식으로 csv 파일을 업로드하였을 때 바디에 파일명 및 정보가 기입됨을 확인하였습니다.
                     * 이에 전송 대상을 csv 파일 내 데이터로 한정하고자 파일정보 3줄 + 공백 1줄을 제하였습니다.(0, 1, 2, 3번 인덱스) */

                    string csvContent = await reader.ReadToEndAsync();
                    /* ReadToEndAsync :
                     * 현 위치부터 끝까지 모든 문자를 읽고, 이를 한 개의 문자열로 반환합니다. 
                     * 이에 코드에서는 문자열 타입 변수 csvContent에 csv 파일에 담긴 모든 문자를 저장합니다. */

                    var csvR = new List<CsvInfoes>();
                    /* 위에서 선언한 BA, ST, LA를 지니는 클래스 CsvInfoes를 담는 신규 배열을 선언합니다.(동적 배열 선언) */

                    string[] csvData = csvContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    /* 0~3줄이 제거된 위치부터 마지막까지 모두 한 문자열로 빚어낸 csvContent를 대상으로
                     * "\n"(줄바꿈 기호)을 기준으로 공백을 제거하여 한 단위씩 csvData라는 문자열 변수 저장 배열에 산입합니다. */

                    foreach (string line in csvData)
                    {
                        string[] values = line.Split(',');
                        /* csvData를 한 줄씩 읽어 마지막줄에 다다를 때까지 반복합니다.
                         * 먼저, 읽어온 줄을 ','(쉼표) 단위로 나누어 문자열 변수 배열 values에 담습니다. */

                        if (values.Length == 3)
                        {
                            var record = new CsvInfoes
                            {
                                BA = values[0],
                                ST = values[1],
                                LA = values[2].Replace("\r", "")
                                /* 총 컬럼은 세 개, 한 줄에 쉼표 두 개로 구분되는 세 개의 데이터가 위치하므로
                                 * 첫 번째를 BA, 두 번째는 ST, 세 번째 데이터는 LA와 매칭합니다.
                                 * "\r" 문자열이 함께 출력되기에 Replace 구문을 통해 제거하였습니다. 
                                 */
                            };
                            csvR.Add(record);
                        }
                        /* csv의 Row마다 사용자 실수 없이 온전히 3개의 데이터만 기입되었다면 이들을 CsvInfoes(기존에 선언한 문자열 BA, ST, LA 를 지닌 클래스)
                         * 내 각 변수와 대응하여 값을 설정하고, CsvInfoes 클래스를 담는 배열 csvR에 입력합니다.*/
                    }
                    /* foreach문 : 향상된 for 문으로, 객체 내 데이터를 조회함에 있어 기존 for문보다 높은 편의성을 지닙니다.
                     *             그러나, 기존 for문에서 가능하였던 내부 데이터 편집이 불가하다는 한계 또한 지니고 있습니다.
                     * 편집 없이 반복 조회가 필요한 상황이었기에 foreach 문을 사용하였습니다. */
                    
                    return Ok(csvR);
                }
            }
            catch (Exception ex)
            {
                // 에러 처리
                return BadRequest("에러 발생. 메시지는 다음과 같습니다. : " + ex.Message);
            }
            /* try - catch 문의 예외 처리 파트. 문제 발생 시 대상 에러 메시지를 return합니다. */
        }
    }
}