namespace _08_create_user
{
    using System.Data.Entity;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}