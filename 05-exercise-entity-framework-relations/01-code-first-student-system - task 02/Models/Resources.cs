namespace _01_code_first_student_system.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Resources
    {
        public Resources()
        {
            Cources = new HashSet<Course>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^video|presentation|document|other")]
        public string TypeOfResource { get; set; }
        [Required]
        public string URL { get; set; }
        public virtual ICollection<Course> Cources { get; set; }
    }
}
