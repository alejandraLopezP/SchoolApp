using System;
using System.Collections.Generic;
using System.Text;

namespace School_Logic.Infrastructure
{
    public interface IIdentificable
    {
        public int Id { get; set; }

      
    }
    public interface INameable
    {
        public string Name { get; set; }
    }

    public interface ILastNameable
    {
        public string LastName { get; set; }
    }
    public interface IEmailable
    {
        public string Email { get; set; }
    }

    public interface ITelefonable
    {
        public string Phone { get; set; }
    }

    //public interface ITrainer
    //{
    //    public string TeachingArea { get; set; }
    //}

    
}
