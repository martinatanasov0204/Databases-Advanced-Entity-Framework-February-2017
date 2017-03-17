namespace _06_albums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photographers
    {
        public Photographers()
        {
            Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime Birthdate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
