using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public interface IEmployee
    {
        int Employedid { get; set; } 
        string Gender { get; set; } 
        string Cites { get; set; }
        //DateTime? DateOfBirth { get; set; }
    }
    public class Employee : IEmployee
    {
        public int Employedid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Cites { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}