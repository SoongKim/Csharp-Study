using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp5.Model
{
    public class Ex001
    {
        public void Run()
        {
            Car001 car = new Car001();
            car.Color = "빨간 색";
            car.Size = "스포츠카";

            Console.WriteLine("고객님의 차는 {0} {1}입니다.", car.Color, car.Size);
            string userCarTyle = car.Color + " " + car.Size;
            Console.WriteLine("{0} (이/가) {1}", userCarTyle, car.Engine_on());
            
        }
    }
    class Car001
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public string Engine_on()
        {
            return "시동을 겁니다.";
        }
        public void Engine_off() {
            Console.WriteLine("시동을 끕니다.");
        }
        public void Go()
        {
            Console.WriteLine("전진합니다.");
        }
        public void Back()
        {
            Console.WriteLine("후진합니다.");
        }
        public void Left()
        {
            Console.WriteLine("좌회전합니다.");
        }
        public void Right() {
            Console.WriteLine("우회전합니다.");
        }
    }
}
