namespace _04_resource_licenses
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

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TypeOfResource { get; set; }

        [Required]
        public string URL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }
        public virtual ICollection<License> Licenses { get; set; }

    }
}
