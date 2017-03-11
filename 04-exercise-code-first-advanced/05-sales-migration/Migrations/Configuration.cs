namespace _05_sales_migration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_05_sales_migration.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_05_sales_migration.SalesContext context)
        {
            var customer = new Customers()
            {
                FirstName = "Pesho",
                LastName = "Petrov"
            };

            var customer2 = new Customers()
            {
                FirstName = "Gosho",
                LastName = "Milchev"
            };

            var customer3 = new Customers()
            {
                FirstName = "Martin",
                LastName = "Atanasov"
            };

            context.Customers.AddOrUpdate(customer);
            context.Customers.AddOrUpdate(customer2);
            context.Customers.AddOrUpdate(customer3);

            base.Seed(context);
        }
    }
}
