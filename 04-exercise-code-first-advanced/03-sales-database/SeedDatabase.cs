namespace _03_sales_database
{
    using System;
    using System.Data.Entity;
    using _03_sales_database.Models;
    public class SeedDatabase : DropCreateDatabaseAlways<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            var product = new Product()
            {
                Name ="Mushroom",
                Quantity = 12,
                Price = 12.50m

            };

            var product2 = new Product()
            {
                Name = "Pizza",
                Quantity = 8,
                Price = 9.20m

            };

            var product3 = new Product()
            {
                Name = "Stone",
                Quantity = 13,
                Price = 5.7m

            };

            var customer = new Customer()
            {
                Name = "Martin",
                Email = "martin@aaa.com",
                CreditCardNumber = "13243260521"
            };

            var customer2 = new Customer()
            {
                Name = "Gosho",
                Email = "gosho@aaa.com",
                CreditCardNumber = "0546454312"
            };

            var customer3 = new Customer()
            {
                Name = "Lesho",
                Email = "lesho@aaa.com",
                CreditCardNumber = "64230343543"
            };

            var storeLocation = new StoreLocation()
            {
                LocationName = "Kazanlak"
            };

            var storeLocation2 = new StoreLocation()
            {
                LocationName = "Varna"
            };

            var storeLocation3 = new StoreLocation()
            {
                LocationName = "Burgas"
            };

            var sale = new Sale()
            {
                Product = product,
                Customer = customer2,
                StoreLocation = storeLocation3,
                Date = new DateTime(2016, 10, 20)
            };

            var sale2 = new Sale()
            {
                Product = product2,
                Customer = customer,
                StoreLocation = storeLocation2,
                Date = new DateTime(2017, 3, 5)
            };

            var sale3 = new Sale()
            {
                Product = product3,
                Customer = customer3,
                StoreLocation = storeLocation,
                Date = new DateTime(2017, 3, 10)
            };

            context.Products.Add(product);
            context.Products.Add(product2);
            context.Products.Add(product3);

            context.Customers.Add(customer);
            context.Customers.Add(customer2);
            context.Customers.Add(customer3);

            context.StoreLocations.Add(storeLocation);
            context.StoreLocations.Add(storeLocation2);
            context.StoreLocations.Add(storeLocation3);

            context.Sales.Add(sale);
            context.Sales.Add(sale2);
            context.Sales.Add(sale3);

            base.Seed(context);
        }
    }
}
