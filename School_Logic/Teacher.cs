using School_Logic.Infrastructure;
using System.Collections.Generic;

namespace School_Logic
{
    public class Teacher : IIdentificable, INameable, ILastNameable, IEmailable, ITelefonable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Course Course { get; set; }
     
        public override string ToString()
        {
            //falta hacer la union con Course
            return $"{Id} ; {Name} ; {LastName} ; {Email} ; {Phone}";
        }
    }
}
