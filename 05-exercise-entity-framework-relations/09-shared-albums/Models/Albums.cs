namespace _09_shared_albums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Albums
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Albums()
        {
            Tags = new HashSet<Tags>();
            Photographerss = new HashSet<Photographers>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool Private { get; set; }

        public int? Photographer_Id { get; set; }

        public int? Picture_Id { get; set; }

        public virtual Photographers Photographers { get; set; }

        public virtual Pictures Pictures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tags> Tags { get; set; }

        public virtual ICollection<Photographers> Photographerss { get; set; }

    }
}
