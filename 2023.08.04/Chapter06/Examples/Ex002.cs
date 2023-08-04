using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex002
    {
        public void Run()
        {
            // step01. 배열 선언
            string[] weather = new string[7];
            // step02. 배열 초기 값 입력
            weather[0] = "sunny";
            weather[1] = "sunny";
            weather[2] = "rainy";
            weather[3] = "cloudy";
            weather[4] = "rainy";
            weather[5] = "snow";
            weather[6] = "sunny";

            // step03. 배열 가져오기
            int dayCnt = weather.Length;

            int sunnyCnt = 0;
            int cloudyCnt = 0;
            int rainyCnt = 0;
            int snowCnt = 0;

            for(int idx = 0; idx < dayCnt; idx++)
            {
                string weathers = weather[idx];
                if (weathers.Equals("sunny"))
                {
                    sunnyCnt++;
                }
                else if (weathers.Equals("cloudy"))
                {
                    cloudyCnt++;
                }
                else if (weathers.Equals("rainy"))
                {
                    rainyCnt++;
                }
                else if (weathers.Equals("snow"))
                {
                    snowCnt++;
                }
            }
            Console.WriteLine("맑음 : {0}회 / 흐림 : {1}회 / " +
                "비 : {2} / 눈 : {3}", sunnyCnt, cloudyCnt, rainyCnt, snowCnt);
        }
    }
}
