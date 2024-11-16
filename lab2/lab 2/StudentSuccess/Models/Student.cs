using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSuccess.Models
{
    class Student
    {
        public readonly int Id;
        private string name;
        private string faculty;
        private string department;
        private int course;
        private Dictionary<string, float> grades;
    }
}
