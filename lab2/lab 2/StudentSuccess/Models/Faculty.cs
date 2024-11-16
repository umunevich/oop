using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSuccess.Models
{
    class Faculty
    {
        private List<Student> students;

        public Faculty() { 
            students = new List<Student>();
        }

        public void AddStudent(Student student) {
            students.Add(student);
        }
    }
}
