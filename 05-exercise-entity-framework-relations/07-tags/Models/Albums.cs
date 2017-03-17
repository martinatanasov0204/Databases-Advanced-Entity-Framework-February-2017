namespace _07_tags
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Albums
    {
        public Albums()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool Private { get; set; }

        public int? Photographer_Id { get; set; }

        public int? Picture_Id { get; set; }

        public virtual Photographers Photographers { get; set; }

        public virtual Pictures Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
