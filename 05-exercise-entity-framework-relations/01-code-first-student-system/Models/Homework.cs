namespace _01_code_first_student_system.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Homework
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [RegularExpression("^application|pdf|zip")]
        public string ContentType { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        public Student Student { get; set; }
    }
}
