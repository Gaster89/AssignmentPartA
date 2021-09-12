using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPartA
{
    public class People
    {
        public int Id { get;  set; }
        public string FirstName {  get; set;  }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Type { get;  set; }
        public People(int id, string firstname, string lastname, string email)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Type = this.GetType().Name;
        }
        public override string ToString()
        {
            return $"{this.Type}: Id[{this.Id}, {this.FirstName}, {this.LastName}, {this.Email}]";
        }
    }
}
