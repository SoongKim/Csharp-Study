using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cp5.Model
{
    public class Ex008
    {
        public void Run()
        {
            GasolineCar gsCar = new GasolineCar();
            Console.WriteLine("가솔린 차량의 색상을 입력해주세요.");
            gsCar.Color = Console.ReadLine() + "색";
            Console.WriteLine("가솔린 차량의 차종을 입력해주세요.");
            gsCar.Size = Console.ReadLine();

            Console.WriteLine("가솔린 차량은 {0} {1}입니다.",
                gsCar.Color, gsCar.Size);
            gsCar.InputGas();

            ElectronicCar enCar = new ElectronicCar();
            Console.WriteLine("전기 차량의 색상을 입력해주세요.");
            enCar.Color = Console.ReadLine() + "색";
            Console.WriteLine("전기 차량의 차종을 입력해주세요.");
            enCar.Size = Console.ReadLine();

            Console.WriteLine("가솔린 차량은 {0} {1}입니다.",
                enCar.Color, enCar.Size);
            enCar.InputGas();

        }
    }

    class Cars
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public string Engine_on()
        {
            return "시동을 켭니다.";
        }
        public string Engine_off()
        {
            return "시동을 끕니다.";
        }
        public string Go()
        {
            return "전진합니다.";
        }
        public string Back()
        {
            return "후진합니다.";
        }
        public string Left()
        {
            return "좌회전합니다.";
        }
        public string Right()
        {
            return "우회전합니다.";
        }
        // virtual : 상속하기 위해 만든 임의의 메서드.
        // Override 받은 피상속 객체들이 사용할 것이다. 구조만 잡는다.
        public virtual void InputGas()
        {
            Console.WriteLine("기름을 넣습니다.");
        }

    }
    // 상속 구조.
    // class 선언 / 선언한 클래스명 : 상속받을 대상 클래스명 { }
    class GasolineCar : Cars
    {
        public override void InputGas()
        {
            Console.WriteLine("휘발유를 넣습니다.");
        }
    }
    class ElectronicCar : Cars
    {
        public override void InputGas()
        {
            Console.WriteLine("전기를 넣습니다.");
        }
    }
}
