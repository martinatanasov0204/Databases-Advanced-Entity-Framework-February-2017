namespace _08_addresses_by_town_name
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Filter addresses

            var addresses = softUniContext.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(e => e.Towns.Name)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", address.AddressText, address.Towns.Name, address.Employees.Count);
            }
        }
    }
}
