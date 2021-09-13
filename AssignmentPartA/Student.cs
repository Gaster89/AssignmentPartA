using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class Student : People
    {
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public Student(int id, string firstname, string lastname, string email) :
                base(id, firstname, lastname, email)
        { }
    }
}
