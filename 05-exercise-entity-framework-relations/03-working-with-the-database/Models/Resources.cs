namespace _03_working_with_the_database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Resources
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resources()
        {
            Courses = new HashSet<Courses>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TypeOfResource { get; set; }

        [Required]
        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

    }
}
