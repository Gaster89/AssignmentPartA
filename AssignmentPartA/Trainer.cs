using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class Trainer : People
    {
        public Trainer(int id, string firstname, string lastname, string email) :
            base(id, firstname, lastname, email)
        { }
    }
}
