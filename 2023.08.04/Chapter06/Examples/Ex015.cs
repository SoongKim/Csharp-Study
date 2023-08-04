using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples.Model;

namespace Chapter06.Examples
{
    public class Ex015
    {
        public void Run()
        {
            List<Student> arrStudent = new List<Student>();
            Student student = new Student();
            student.Id = "S001";
            student.Name = "홍길동";
            student.DepartMent = "국어국문학과";
            student.Grade = "1";
            student.Age = 21;

            arrStudent.Add(student);

            for (int i = 0; i < arrStudent.Count; i++)
            {
                Console.WriteLine((arrStudent[i]).Id);
                Console.WriteLine((arrStudent[i]).Name);
                Console.WriteLine((arrStudent[i]).DepartMent);
                Console.WriteLine((arrStudent[i]).Grade);
                Console.WriteLine((arrStudent[i]).Age);
            }
        }
    }
}
