using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        public List<Student> Students { get; set; } = new List<Student>();


        public bool CreateCourse(string name)
        {
            Course course = new Course(this.Courses.Count, name, this);
            this.Courses.Add(course);
            return this.Courses.Contains(course) ? true : false;
        }

        public bool RemoveCourse(Course course)
        {
            this.Courses.Remove(course);
            return (!this.Courses.Contains(course)) ? true : false;
        }

        public bool CreateTrainer(string firstname, string lastname, string email)
        {
            Trainer trainer = new Trainer(this.Trainers.Count, firstname, lastname, email);
            this.Trainers.Add(trainer);
            return this.Trainers.Contains(trainer) ? true : false;
        }

        public bool RemoveTrainer(Trainer trainer)
        {
            this.Trainers.Remove(trainer);
            return (!this.Trainers.Contains(trainer)) ? true : false;
        }

        public bool CreateStudent(string firstname, string lastname, string email)
        {
            Student student = new Student(this.Students.Count, firstname, lastname, email);
            this.Students.Add(student);
            return this.Students.Contains(student) ? true : false;
        }

        public bool RemoveStudent(Student student)
        {
            this.Students.Remove(student);
            return (!this.Students.Contains(student)) ? true : false;
        }

        public Course GetCourseById(int id)
        {
            return (from course in this.Courses where course.Id == id select course).FirstOrDefault();
        }

        public Trainer GetTrainerById(int id)
        {
            return (from trainer in this.Trainers where trainer.Id == id select trainer).FirstOrDefault();
        }

        public Student GetStudentById(int id)
        {
            return (from student in this.Students where student.Id == id select student).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"School: ID[{this.Id}], {this.Name}";
        }
    }
}
