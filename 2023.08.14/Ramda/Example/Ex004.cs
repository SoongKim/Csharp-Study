using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramda.Example
{
    internal class Ex004
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
            int countNumber = students.Where(target => target.GRADE >= 3).ToList().Count();
            Console.WriteLine("고학년 인원의 총 수는 '{0}'명입니다.", countNumber);
            Console.WriteLine("====================================");
            Console.WriteLine("고학년 인원 명단은 다음과 같습니다.");
            students.Where(target => target.GRADE >= 3)
                    .OrderBy(target => target.GRADE)
                    .ThenBy(target => target.NAME)
                    .ToList()
                    .ForEach(target => Console.WriteLine("{0} : {1}",
                    target.GRADE, target.NAME));

            students.OrderBy(s => s.GRADE).ToList()
                .ForEach(s => Console.WriteLine("{0}:{1}:{2}:{3}",
                s.ID, s.NAME, s.GRADE, s.MAJOR));
        }
    }
}
