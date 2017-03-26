namespace _02_advanced_mapping.Classes
{
    using System;
    using System.Collections.Generic;
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
        public bool OnHoliday { get; set; }
        public Employee Manager { get; set; }
        public virtual ICollection<Employee> ManagerOf { get; set; }       
    }
}
