namespace _04_products_migration
{
    using System.Collections.Generic;

    public partial class StoreLocations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoreLocations()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }

        public string LocationName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
