using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_tags
{
    public class Tag
    {
        public Tag()
        {
            Albums = new HashSet<Albums>();
        }
        public int Id { get; set; }

        [Index("IX_Signature", 1, IsUnique = true)]
        public string Signature { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
    }
}
