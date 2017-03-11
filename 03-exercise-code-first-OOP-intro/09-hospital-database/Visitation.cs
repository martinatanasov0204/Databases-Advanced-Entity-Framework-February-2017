namespace _09_hospital_database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Visitation
    {
        public Visitation()
        {
            Comments = new List<string>();
        }
        [Key]
        public int Id { get; set; }

        public DateTime VisitationDateTime { get; set; }

        public ICollection<string> Comments { get; set; }

        public int DoctorId { get; set; }
    }
}
