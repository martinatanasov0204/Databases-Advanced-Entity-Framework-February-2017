using System.Collections.Generic;

namespace _06_albums
{
    public class Picture
    {
        public Picture()
        {
            Albums = new HashSet<Album>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string PathOnFileSystem { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
