namespace _01_local_store
{
    class Startup
    {
        static void Main()
        {
            var context = new GickaContext();
            
            var product = new Product()
            {
                Name = "Omar",
                DistributorName = "Pesho",
                Description = "Some description",
                Price = 20.5m
            };

            var product2 = new Product()
            {
                Name = "Pizza",
                DistributorName = "Gosho",
                Description = "Description",
                Price = 18.8m
            };

            var product3= new Product()
            {
                Name = "Cake",
                DistributorName = "Lesho",
                Description = "Desc",
                Price = 12.4m
            };

            context.Products.Add(product);
            context.Products.Add(product2);
            context.Products.Add(product3);

            context.SaveChanges();
        }
    }
}
