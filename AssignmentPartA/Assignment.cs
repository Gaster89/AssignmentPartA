using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get ; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get ; set; }
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Assignment(int id, string name, Course course)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = DateTime.Today;
            this.EndDate = DateTime.Today.AddMonths(1);
            this.Course = course;
        }

        public bool SetTrainer(Trainer trainer)
        {
            this.Trainer = trainer;
            return this.Trainer != null ? true : false;
        }

        public bool AddStudent(Student student)
        {
            this.Students.Add(student);
            return this.Students.Contains(student) ? true : false;
        }

        public bool DelStudent(Student student)
        {
            this.Students.Remove(student);
            return (!this.Students.Contains(student)) ? true : false;
        }

        public override string ToString()
        {
            return $"Assignment: ID[{this.Id}], {this.Name}, StartDate: {this.StartDate}, EndDate: {this.EndDate}";
        }
    }
}
