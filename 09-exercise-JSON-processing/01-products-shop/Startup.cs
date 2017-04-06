namespace _01_products_shop
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using _01_products_shop.Models;
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var context = new ProjectsContext();

            // problem 02 => importUsers(context), importProducts(context), importCategories(context), importCategories(context), addCategoryForProducts(context)

            // problem 03 => ProductsInRange(context), SuccessfullySoldProducts(context), CategoriesByProductsCount(context)
        }

        private static void importUsers(ProjectsContext context)
        {
            string jsonUsers = File.ReadAllText(@"..\..\Import\users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
        private static void importProducts(ProjectsContext context)
        {
            string jsonProducts = File.ReadAllText(@"..\..\Import\products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
            int randomCount = 1;

            Random rnd = new Random();

            foreach (var product in products)
            {
                product.SellerId = rnd.Next(1, 56);

                randomCount++;
                if (randomCount % 13 == 0)
                {
                    product.BuyerId = rnd.Next(1, 56);
                }
            }
            
            context.Products.AddRange(products);

            context.SaveChanges();
        }
        private static void importCategories(ProjectsContext context)
        {
            string jsonCategories = File.ReadAllText(@"..\..\Import\categories.json");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);

            context.Categories.AddRange(categories);

            context.SaveChanges();
        }
        private static void addCategoryForProducts(ProjectsContext context)
        {
            var randomizer = 2;

            foreach (var category in context.Categories)
            {
                foreach (var product in context.Products)
                {
                    if ((randomizer + 1) % 4 == 0)
                    {
                        product.Categories.Add(category);
                        randomizer++;
                    }
                    randomizer++;
                }
            }

            context.SaveChanges();
        }
        private static void ProductsInRange(ProjectsContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 500 && p.Price < 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                });

            var jsonProducts = JsonConvert.SerializeObject(products, (Newtonsoft.Json.Formatting)Formatting.Indented);
            Console.WriteLine(jsonProducts);
        }
        private static void SuccessfullySoldProducts(ProjectsContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count != 0)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold.Where(ps => ps.Buyer.LastName != null).Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName);

            string jsonUsers = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonUsers);
        }
        private static void CategoriesByProductsCount(ProjectsContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalAvenue = c.Products.Sum(p => p.Price)
                });

            string jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(jsonCategories);
        }
    }
}
