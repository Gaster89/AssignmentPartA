using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    class Program
    {
        static void Main(string[] args)
        {

            Student st = new Student(1, "MitsosS", "GasteratosS", "mg@gmail.com");
            Console.WriteLine(st.ToString());
            Trainer tr = new Trainer(2, "MitsosT", "GasteratosT", "mg@gmail.com");
            Console.WriteLine(tr.ToString());

            Console.ReadKey();
        }
    }
}
