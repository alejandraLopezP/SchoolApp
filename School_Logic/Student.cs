using School_Logic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School_Logic
{

    public class Student : IIdentificable, INameable, ILastNameable, IEmailable, ITelefonable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            this.Courses = new List<Course>();
        }
        public override string ToString()
        {
            return $"{Id} ; {Name} ; {LastName} ; {Email} ; {Phone}";
        }

    }
}
