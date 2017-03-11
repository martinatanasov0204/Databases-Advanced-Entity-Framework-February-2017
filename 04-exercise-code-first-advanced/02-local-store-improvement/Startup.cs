namespace _02_local_store_improvement
{
    class Startup
    {
        static void Main()
        {
            var context = new GickaContext();

            var product = new Products()
            {
                Name = "Omar",
                DistributorName = "Pesho",
                Description = "Some description",
                Price = 20.5m,
                Weight = 3.2m,
                Quantity = 4.1m
            };

            var product2 = new Products()
            {
                Name = "Pizza",
                DistributorName = "Gosho",
                Description = "Description",
                Price = 18.8m,
                Weight = 2,
                Quantity = 2.2m
            };

            var product3 = new Products()
            {
                Name = "Cake",
                DistributorName = "Lesho",
                Description = "Desc",
                Price = 12.4m,
                Weight = 6,
                Quantity = 8
            };

            context.Products.Add(product);
            context.Products.Add(product2);
            context.Products.Add(product3);

            context.SaveChanges();
        }
    }
}
