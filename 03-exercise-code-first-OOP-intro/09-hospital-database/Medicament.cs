namespace _09_hospital_database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Medicament
    {
        public Medicament()
        {
            MedicamentPatients = new List<Patient>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> MedicamentPatients { get; set; }
    }
}
