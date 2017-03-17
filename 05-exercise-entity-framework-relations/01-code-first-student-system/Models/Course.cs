namespace _01_code_first_student_system.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
            Resources = new HashSet<Resources>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Resources> Resources { get; set; }

    }
}
