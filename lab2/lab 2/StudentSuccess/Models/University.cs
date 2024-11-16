using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSuccess.Models
{
    class University
    {
        private List<Student> students;
        private List<Faculty> faculties;

        private University() { 
            this.students = new List<Student>();
            this.faculties = new List<Faculty>();
        }

        public void ImportFromXML(string file_name) {

        }

        public void ExportToXML(string file_name) {

        }

        public void ExportToHTML(string file_name) { 
        
        }
    }
}
