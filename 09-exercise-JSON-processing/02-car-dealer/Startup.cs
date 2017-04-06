namespace _02_car_dealer
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using _02_car_dealer.Models;
    class Startup
    {
        static void Main()
        {
            var context = new CarDealerContext();

            // problem 05 => ImportSuppliers(context), ImportParts(context), ImportCars(context), ImportCustomers(context), ImportSales(context)
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            string jsonSuppliers = File.ReadAllText(@"..\..\Import\suppliers.json");
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(jsonSuppliers);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();
        }
        private static void ImportParts(CarDealerContext context)
        {
            string jsonParts = File.ReadAllText(@"..\..\Import\parts.json");
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(jsonParts);

            Random rnd = new Random();

            foreach (var part in parts)
            {
                part.SupplierId = rnd.Next(1, 31);
            }

            context.Parts.AddRange(parts);

            context.SaveChanges();
        }
        private static void ImportCars(CarDealerContext context)
        {
            string jsonCars = File.ReadAllText(@"..\..\Import\cars.json");

            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(jsonCars);

            Random rnd = new Random();

            foreach (var car in cars)
            {
                for (int i = 0; i < rnd.Next(10, 20); i++)
                {
                    var rndn = rnd.Next(1, 131);
                    car.Parts.Add(context.Parts.Where(p => p.Id == rndn).FirstOrDefault());
                }
            }

            context.Cars.AddRange(cars);

            context.SaveChanges();
        }
        private static void ImportCustomers(CarDealerContext context)
        {
            string jsonCustomers = File.ReadAllText(@"..\..\Import\customers.json");

            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(jsonCustomers);


            context.Customers.AddRange(customers);

            context.SaveChanges();
        }
        private static void ImportSales(CarDealerContext context)
        {
            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                var rndCustId = rnd.Next(1, 31);
                var rndCarId = rnd.Next(1, 358);

                var sale = new Sale()
                {
                    Discount = 10 * rnd.Next(1, 5),
                    Customer = context.Customers.Where(c => c.Id == rndCustId).FirstOrDefault(),
                    Car = context.Cars.Where(c => c.Id == rndCarId).FirstOrDefault()
                };

                context.Sales.Add(sale);

                context.SaveChanges();
            }
        }
    }
}
