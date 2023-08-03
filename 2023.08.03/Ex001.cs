using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05.Lab
{
    public class Ex001
    {
        public void Run()
        {
            Car001 car = new Car001();
            car.setSize("세단");
            car.setColor("하얀");

            Console.WriteLine("고객님의 차는 {0} {1} ", car.getColor(), car.getSize());

            car.Engine_on();
            car.GO();
            car.Back();
            car.Left();
            car.Right();
            car.Engine_off();
        }
    }

    class Car001
    {
        #region >> 형태
        private string size;
        private string color;

        public void setSize(string size)
        {
            this.size = size;
        }
        public string getSize()
        {
            return size;
        }
        #endregion
        public void setColor(string color)
        {
            this.color = color;
        }
        public string getColor()
        {
            return color;
        }

        public void Engine_on()
        {
            Console.WriteLine("시동을 겁니다.");
        }
        public void Engine_off()
        {
            Console.WriteLine("시동을 끕니다.");
        }
        public void GO()
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
        public void Right()
        {
            Console.WriteLine("우회전합니다.");
        }

    }

}