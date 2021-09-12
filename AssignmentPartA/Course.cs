using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Trainer Trainers { get; set; }
        public School School { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public Course(int id, string name, School school)
        {
            this.Id = id;
            this.Name = name;
            this.StartDate = DateTime.Today;
            this.EndDate = DateTime.Today.AddMonths(6);
            this.School = school;
        }

        public bool SetTrainer(Trainer trainer)
        {
            this.Trainers = trainer;
            return (this.Trainers != null) ? true  : false;
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

        public bool CreateAssignment(string name)
        {
            Assignment assignment = new Assignment(this.Assignments.Count, name, this);
            this.Assignments.Add(assignment);
            return this.Assignments.Contains(assignment) ? true : false;
        }

        public bool RemoveAssignment(Assignment assignment)
        {
            this.Assignments.Remove(assignment);
            return (!this.Assignments.Contains(assignment)) ? true : false;
        }

        public Assignment GetAssignmentById(int id)
        {
            return (from ass in this.Assignments where ass.Id == id select ass).FirstOrDefault();
        }

        public Student GetStudentById(int id)
        {
            return (from student in this.Students where student.Id == id select student).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"Course: ID[{this.Id}], {this.Name}, StartDate: {this.StartDate}, EndDate: {this.EndDate}";
        }
    }
}
