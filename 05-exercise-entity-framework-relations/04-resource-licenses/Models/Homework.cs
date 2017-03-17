namespace _04_resource_licenses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int? Student_Id { get; set; }

        public virtual Students Students { get; set; }
    }
}
