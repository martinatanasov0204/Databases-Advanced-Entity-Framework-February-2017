namespace _01_code_first_student_system.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
            Homeworks = new HashSet<Homework>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
