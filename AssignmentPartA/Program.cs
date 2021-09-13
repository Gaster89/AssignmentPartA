using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AssignmentPartA
{
    class Program
    {

        static School school = new School();

        static void Main(string[] args)
        {
            //AddTestRecords testRecords = new AddTestRecords();
            //testRecords.AddRecords();

            while (true)
            {
                Console.WriteLine("Add(a) ? Get(g) ? Edit(e) ? Quit(q):");
                string choice = Console.ReadLine();
                Console.WriteLine("\n");

                // Importing
                if (choice.Equals("a") || choice.Equals("Add"))
                {
                    Console.WriteLine("Example Enter: 3  'to Add a Trainer'.");
                    Console.WriteLine("Import: Course(1) ? Assignment(2) ? Trainer(3) ? Student(4)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "1":
                            AddCourse();
                            break;
                        case "2":
                            AddAssignment();
                            break;
                        case "3":
                            AddTrainer();
                            break;
                        case "4":
                            AddStudent();
                            break;
                        default:
                            Console.WriteLine("Try Again, not a valid command.");
                            break;
                    }
                }
                // Exporting
                else if (choice.Equals("g") || choice.Equals("Get"))
                {
                    Console.WriteLine("Getting records");
                    Console.WriteLine(
                        "Enter for Example: 1\n\t"
                            + "(1)  -->  [ A list of students.                                                                    ]\n\t"
                            + "(2)  -->  [ A list of trainers.                                                                    ]\n\t"
                            + "(3)  -->  [ A list of assignments.                                                                 ]\n\t"
                            + "(4)  -->  [ A list of courses.                                                                     ]\n\t"
                            + "(5)  -->  [ A List of students per course.                                                         ]\n\t"
                            + "(6)  -->  [ A List of trainers per course.                                                         ]\n\t"
                            + "(7)  -->  [ A List of assignments per course.                                                      ]\n\t"
                            + "(8)  -->  [ A List of assignments per student.                                                     ]\n\t"
                            + "(9)  -->  [ A List of students that belong to more than one course.                                ]\n\t"
                            + "(10) -->  [ A List of students who needs to submit one or more assigments due the same week.       ]\n\t"
                    );
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "1":
                            GetStudents();
                            break;
                        case "2":
                            GetTrainers();
                            break;
                        case "3":
                            GetAssignments();
                            break;
                        case "4":
                            GetCourses();
                            break;
                        case "5":
                            GetStudentsOfCourse();
                            break;
                        case "6":
                            GetTrainersOfCourse();
                            break;
                        case "7":
                            GetAssignmentsOfCourse();
                            break;
                        case "8":
                            GetStudentsFromAssignment();
                            break;
                        case "9":
                            GetAllStudentsThatBelongToMoreThatOneCourse();
                            break;
                        case "10":
                            GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice.");
                            break;
                    }
                }
                // Edit Data
                else if (choice.Equals("e") || choice.Equals("Edit"))
                {
                    Console.WriteLine("Example Enter: 1  'to edit Course'.");
                    Console.WriteLine("Edit: Course(1) ? Assignment(2) ? Trainer(3) ? Student(4)");
                    choice = Console.ReadLine();
                    Console.WriteLine("\n");
                    switch (choice)
                    {
                        case "1":
                            CourseEdit();
                            break;
                        case "2":
                            AssignmentEdit();
                            break;
                        case "3":
                            //Trainer.TerminalEdit();
                            break;
                        case "4":
                            //Student.TerminalEdit();
                            break;
                        default:
                            Console.WriteLine("Enter a Valid Choice!");
                            break;
                    }
                }
                // Exit From the program
                else if (choice.Equals("q") || choice.Equals("Quit"))
                {
                    break;
                }
                Console.WriteLine("\n\n");
            }
        }





        static void AssignmentEdit()
        {
            Console.WriteLine("Editing Assignment");
            Console.Write("Select Course By Id: ");
            int id = -1;
            foreach (Course cour in school.Courses)
            {
                Console.WriteLine(cour.ToString());
            }
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);

            Console.Write("Select Assignment By Id: ");
            id = -1;
            foreach (Assignment assigment in course.Assignments)
            {
                Console.WriteLine(assigment.ToString());
            }
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Assignment assignment = course.GetAssignmentById(id);
            Console.WriteLine("Edit: Main Info(1) || Students(2)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Name(1) || Trainer(2) || Course(3): ");
                    choice = Console.ReadLine();
                    switch(choice)
                    {
                        case "1":
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            if(name.Length > 3 && name.Length < 20)
                            {
                                assignment.Name = name;
                            }
                            else
                            {
                                Console.WriteLine("Enter a Valid Name!");
                            }
                            break;
                        case "2":
                            Console.Write("Add(1) || Remove(2)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.WriteLine("Select Trainer By Id: ");
                                    id = -1;
                                    foreach (Trainer tr in school.Trainers)
                                    {
                                        Console.WriteLine(tr.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    Trainer trainer = (from tr in school.Trainers where tr.Id == id select tr).FirstOrDefault();
                                    assignment.Trainer = trainer;
                                    break;
                                case "2":
                                    assignment.Trainer = null;
                                    break;
                                default:
                                    Console.WriteLine("Try again, not a valid choice!");
                                    break;
                            }
                            break;
                        case "3":
                            Console.Write("Add(1) || Remove(2)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.WriteLine("Select Course By Id: ");
                                    id = -1;
                                    foreach (Course cour in school.Courses)
                                    {
                                        Console.WriteLine(cour.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    Course cours = (from c in school.Courses where c.Id == id select c).FirstOrDefault();
                                    assignment.Course = cours;
                                    break;
                                case "2":
                                    assignment.Course = null;
                                    break;
                                default:
                                    Console.WriteLine("Try again, not a valid choice!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Try again, not a valid choice!");
                            break;
                    }
                    break;
                case "2":
                    Console.Write("Add(1) || Remove(2)");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Select Student By Id: ");
                            id = -1;
                            foreach (Student st in school.Students)
                            {
                                Console.WriteLine(st.ToString());
                            }
                            try
                            {
                                id = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Try Again, not a valid Id!");
                            }
                            Student student = (from st in school.Students where st.Id == id select st).FirstOrDefault();
                            if (assignment.AddStudent(student))
                            {
                                Console.WriteLine("Student Added!");
                            }
                            else
                            {
                                Console.WriteLine("Faild");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Select Student By Id: ");
                            id = -1;
                            foreach (Student st in assignment.Students)
                            {
                                Console.WriteLine(st.ToString());
                            }
                            try
                            {
                                id = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Try Again, not a valid Id!");
                            }
                            student = (from st in assignment.Students where st.Id == id select st).FirstOrDefault();
                            if (assignment.DelStudent(student))
                            {
                                Console.WriteLine("Trainer Deleted!");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                            break;
                        default:
                            Console.WriteLine("Try again, not a valid choice!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Try again, not a valid choice!");
                    break;
            }
        }

        static void CourseEdit()
        {
            Console.WriteLine("Editing Course");
            Console.Write("Select Course By Id: ");
            int id = -1;
            foreach(Course cour in school.Courses)
            {
                Console.WriteLine(cour.ToString());
            }
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            Console.WriteLine("Edit: Main Info(1) || Ralated Records(2)");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    if(name.Length > 3 && name.Length < 20)
                    {
                        course.Name = name;
                    }
                    else
                    {
                        Console.WriteLine("Try again, not a valid name!");
                    }
                    break;
                case "2":
                    Console.WriteLine("Edit: Assignment(1) || Trainer(2) || Student(3)");
                    choice = Console.ReadLine();
                    switch(choice)
                    {
                        case "1":
                            Console.Write("Add(1) || Remove(2)");
                            choice = Console.ReadLine();
                            switch(choice)
                            {
                                case "1":
                                    Console.Write("Enter Assignment Name: ");
                                    name = Console.ReadLine();
                                    if(name.Length > 3 && name.Length < 20)
                                    {
                                        if ( course.CreateAssignment(name) )
                                        {
                                            Console.WriteLine("Assignment Added");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed");
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Write("Select Assignment By Id: ");
                                    id = -1;
                                    try
                                    {
                                        foreach (Assignment assignment in course.Assignments)
                                        {
                                            Console.WriteLine(assignment.ToString());
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    id = int.Parse(Console.ReadLine());
                                    Assignment ass = course.GetAssignmentById(id);
                                    if ( course.RemoveAssignment(ass) )
                                    {
                                        Console.WriteLine("Assignment Deleted!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Try again, not a valid choice!");
                                    break;
                            }
                            break;
                        case "2":
                            Console.Write("Add(1) || Remove(2)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.WriteLine("Select Trainer By Id: ");
                                    id = -1;
                                    foreach(Trainer tr in school.Trainers)
                                    {
                                        Console.WriteLine(tr.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    Trainer trainer = (from tr in course.Trainers where tr.Id == id select tr).FirstOrDefault();
                                    if(course.AddTrainer(trainer))
                                    {
                                        Console.WriteLine("Trainer Added!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Faild");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Select Trainer By Id: ");
                                    id = -1;
                                    foreach (Trainer tr in course.Trainers)
                                    {
                                        Console.WriteLine(tr.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    trainer = (from tr in course.Trainers where tr.Id == id select tr).FirstOrDefault();
                                    if (course.DelTrainer(trainer))
                                    {
                                        Console.WriteLine("Trainer Deleted!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Try again, not a valid choice!");
                                    break;
                            }
                            break;
                        case "3":
                            Console.Write("Add(1) || Remove(2)");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.WriteLine("Select Student By Id: ");
                                    id = -1;
                                    foreach (Student st in school.Students)
                                    {
                                        Console.WriteLine(st.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    Student student = (from st in course.Students where st.Id == id select st).FirstOrDefault();
                                    if(course.AddStudent(student))
                                    {
                                        Console.WriteLine("Student Added!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Faild");
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("Select Student By Id: ");
                                    id = -1;
                                    foreach (Student st in course.Students)
                                    {
                                        Console.WriteLine(st.ToString());
                                    }
                                    try
                                    {
                                        id = int.Parse(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Try Again, not a valid Id!");
                                    }
                                    student = (from st in course.Students where st.Id == id select st).FirstOrDefault();
                                    if (course.DelStudent(student))
                                    {
                                        Console.WriteLine("Trainer Deleted!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Try again, not a valid choice!");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("Try again, not a valid choice!");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Try again, not a valid choice!");
                    break;
            }
        }


        static void GetAllStudentsWhoNeedToSubmitAssigNmentsOnTheSameWeek()
        {
            Course[] courses = (from course in school.Courses select course).ToArray();
            List<Assignment> assignments = new List<Assignment>();
            foreach(Course course in courses)
            {
                assignments.Add( (from assignment in course.Assignments select assignment).FirstOrDefault() );
            }
            foreach(Assignment assignme in assignments)
            {
                DateTime enddate = assignme.EndDate;
                DateTime currentdate = DateTime.Today;
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                var d1 = enddate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(enddate));
                var d2 = currentdate.Date.AddDays(-1 * (int)cal.GetDayOfWeek(currentdate));
                if (d1 == d2)
                {
                    foreach(Student student in assignme.Students)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
            }
        }

        static void GetAllStudentsThatBelongToMoreThatOneCourse()
        {
            Student[] students = (from student in school.Students where student.Courses.Count > 1 select student).ToArray();
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
        }


        static void GetStudentsFromAssignment()
        {
            Console.WriteLine("Get Students From Assignment: ");
            Console.Write("Sletect Course Of This Assignment By Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            Console.Write("Select Assignment By Id: ");
            foreach (Assignment ass in course.Assignments)
            {
                Console.WriteLine(ass.ToString());
            }
            id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Assignment assignment = course.GetAssignmentById(id);
            foreach(Student student in assignment.Students)
            {
                Console.WriteLine(student.ToString());  ;
            }
        }

        static void GetAssignmentsOfCourse()
        {
            Console.WriteLine("Get Assignments Of Course: ");
            Console.Write("Select Course By Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            foreach (Assignment assignment in course.Assignments)
            {
                Console.WriteLine(assignment.ToString());
            }
        }


        static void GetTrainersOfCourse()
        {
            Console.WriteLine("Get Trainers Of Course: ");
            Console.Write("Sletect Course By Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            foreach (Trainer trainer in course.Trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }


        static void GetStudentsOfCourse()
        {
            Console.WriteLine("Get Students Of Course: ");
            Console.Write("Sletect Course By Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            foreach(Student student in course.Students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        static void GetStudents()
        {
            Console.WriteLine("Get Students: ");
            foreach(Student student in school.Students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        static void GetTrainers()
        {
            Console.WriteLine("Get Trainers: ");
            foreach (Trainer trainer in school.Trainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        static void GetAssignments()
        {
            Console.WriteLine("Get Assignments: ");
            Console.Write("Sletect Course By Id: ");
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
            }
            Course course = school.GetCourseById(id);
            foreach (Assignment assignment in course.Assignments)
            {
                Console.WriteLine(assignment.ToString());
            }
        }

        static void GetCourses()
        {
            Console.WriteLine("Get Courses: ");
            foreach (Course course in school.Courses)
            {
                Console.WriteLine(course.ToString());
            }
        }


        static bool AddCourse()
        {
            Console.WriteLine("Create a New Course:");
            Console.Write("Enter a Name: ");
            string name = Console.ReadLine();
            if  (name.Length > 3 && name.Length < 20)
            {
                return school.CreateCourse(name);
            }
            else
            {
                return false;
            }
        }

        static bool AddAssignment()
        {
            Console.Write("Select a Course by Id: ");
            foreach(Course course in school.Courses)
            {
                Console.WriteLine(course.ToString());
            }
            int id = -1;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Try Again, not a valid Id!");
                return false;
            }
            if (id != -1)
            {
                Course course = school.GetCourseById(id);
                Console.Write("Enter Assignments Name: ");
                string name = Console.ReadLine();
                return course.CreateAssignment(name);
            }
            else
            {
                return false;
            }
        }

        static bool AddTrainer()
        {
            Console.WriteLine("Add a New Trainer:");
            Console.Write("Enter First Name: ");
            string fname = Console.ReadLine();
            if (fname.Length > 3 && fname.Length < 20)
            {
                Console.Write("Enter Last Name: ");
                string lname = Console.ReadLine();
                if (lname.Length > 3 && lname.Length < 20)
                {
                    Console.Write("Enter an Email: ");
                    string email = Console.ReadLine();
                    if (email.Length > 3 && email.Length < 20)
                    {
                        return school.CreateTrainer(fname, lname, email);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static bool AddStudent()
        {
            Console.WriteLine("Add a New Student:");
            Console.Write("Enter First Name: ");
            string fname = Console.ReadLine();
            if (fname.Length > 3 && fname.Length < 20)
            {
                Console.Write("Enter Last Name: ");
                string lname = Console.ReadLine();
                if (lname.Length > 3 && lname.Length < 20)
                {
                    Console.Write("Enter an Email: ");
                    string email = Console.ReadLine();
                    if ( Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) )
                    {
                        return school.CreateStudent(fname, lname, email);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



    }

}
