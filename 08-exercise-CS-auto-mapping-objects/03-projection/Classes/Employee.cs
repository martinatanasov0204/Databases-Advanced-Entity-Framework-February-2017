using System;
using System.Collections.Generic;

namespace _03_projection.Classes
{
    public class Employee
    {
        public Employee()
        {
            ManagerOf = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public Employee Manager { get; set; }
        public virtual ICollection<Employee> ManagerOf { get; set; }
    }
}
