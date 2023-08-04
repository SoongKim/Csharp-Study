using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06.Examples
{
    public class Ex001
    {
        public void Run()
        {
            string weather = "sunny,sunny,rainy,cloudy,rainy,snow,sunny";
            var weathers = weather.Split(',');

            Console.WriteLine(weather.GetType());
            Console.WriteLine(weathers.GetType());
        }
    }
}
