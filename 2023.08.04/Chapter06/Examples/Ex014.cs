using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter06.Examples.Model;

namespace Chapter06.Examples
{
    public class Ex014
    {
        public void Run()
        {
            ArrayList arrStudent = new ArrayList();

            Student student = new Student();
            student.Id = "S001";
            student.Name = "홍길동";
            student.DepartMent = "국어국문학과";
            student.Grade = "1";
            student.Age = 21;
            
            arrStudent.Add(student);

            for(int i = 0; i < arrStudent.Count; i++)
            {
                Console.WriteLine(((Student)arrStudent[i]).Id);
                Console.WriteLine(((Student)arrStudent[i]).Name);
                Console.WriteLine(((Student)arrStudent[i]).DepartMent);
                Console.WriteLine(((Student)arrStudent[i]).Grade);
                Console.WriteLine(((Student)arrStudent[i]).Age);
            }

        }
    }
}
