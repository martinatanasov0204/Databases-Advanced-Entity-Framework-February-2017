namespace _09_hospital_database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Patient
    {
        public Patient()
        {
            Visitations = new List<Visitation>();
            Diagnoses = new List<Diagnose>();
            Medicaments = new List<Medicament>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DateOFBirth { get; set; }

        public byte[] Picture { get; set; }

        public byte MedicalInsurence { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }
    }
}
