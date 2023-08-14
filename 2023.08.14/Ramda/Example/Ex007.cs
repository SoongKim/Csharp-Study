using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda.Example
{
    internal class Ex007
    {
        public void Run()
        {
            List<Model.Student> students = new List<Model.Student>()
            {
                new Model.Student{ID="S001", NAME="Dexter", GRADE=3, MAJOR="Software"},
                new Model.Student{ID="D001", NAME="Ellin", GRADE=3, MAJOR="Design"},
                new Model.Student{ID="S002", NAME="Jeffrey", GRADE=4, MAJOR="Software"},
                new Model.Student{ID="D002", NAME="Sienna", GRADE=4, MAJOR="Design"},
                new Model.Student{ID="S003", NAME="Pill", GRADE=4, MAJOR="Software"},
                new Model.Student{ID="D003", NAME="Clint", GRADE=3, MAJOR="Software"},
                new Model.Student{ID="S004", NAME="Khan", GRADE=2, MAJOR="Software"},
                new Model.Student{ID="D004", NAME="Mike", GRADE=2, MAJOR="Advertisement"},
                new Model.Student{ID="S005", NAME="Sven", GRADE=2, MAJOR="Software"},
                new Model.Student{ID="D005", NAME="Peter", GRADE=1, MAJOR="Theater"},
            };
            //Console.WriteLine("1학년 혹은 3학년인 학생의 명부를 출력합니다.");
            //students.Where(s => s.GRADE == 1 || s.GRADE == 3)
            //        .OrderBy(s => s.GRADE).ThenBy(s => s.NAME)
            //        .ToList()
            //        .ForEach(s => Console.WriteLine("{0} : {1}", s.GRADE, s.NAME));
            //Console.ReadKey();

            //Console.WriteLine("고학년 학생의 명부를 출력합니다.");
            //students.Where(s => s.GRADE >= 3)
            //    .OrderBy(s => s.GRADE).ThenBy(s => s.NAME).ToList()
            //    .ForEach(s => Console.WriteLine("{0} : {1}", s.GRADE, s.NAME));

            //Console.WriteLine("학년 순으로 오름차순하여 출력합니다.");
            //students.OrderBy(s => s.GRADE).ThenBy(s => s.NAME).ToList()
            //        .ForEach(s => Console.WriteLine("{0}:{1}:{2}:{3}",
            //        s.ID, s.NAME, s.GRADE, s.MAJOR));

            Console.WriteLine("전공별 학생 수를 출력합니다.");
            students.GroupBy(s => s.MAJOR, (key, g) => new {MAJOR = key, Count = g.Count()})
                .ToList().ForEach(
                s => Console.WriteLine("{0} : {1}", s.MAJOR, s.Count));
        }
    }
}