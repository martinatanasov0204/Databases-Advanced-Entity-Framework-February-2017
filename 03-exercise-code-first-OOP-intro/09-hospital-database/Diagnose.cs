namespace _09_hospital_database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Diagnose
    {
        public Diagnose()
        {
            Comments = new HashSet<string>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<string> Comments { get; set; }
    }
}
