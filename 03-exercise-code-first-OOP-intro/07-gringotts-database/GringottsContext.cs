namespace _07_gringotts_database
{
    using System.Data.Entity;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

        public virtual DbSet<WizardDeposits> Wizzards { get; set; }
    }
}