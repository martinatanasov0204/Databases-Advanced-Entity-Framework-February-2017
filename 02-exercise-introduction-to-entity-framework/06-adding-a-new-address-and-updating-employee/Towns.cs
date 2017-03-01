namespace _06_adding_a_new_address_and_updating_employee
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Towns
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Towns()
        {
            Addresses = new HashSet<Addresses>();
        }

        [Key]
        public int TownID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
