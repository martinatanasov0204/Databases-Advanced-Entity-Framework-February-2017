namespace _05_photographers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyContext : DbContext
    {
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PhotographyContext>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }
    }
}