namespace _06_adding_a_new_address_and_updating_employee
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Create new address

            var address = new Addresses();
            address.AddressText = "Vitoshka 15";
            address.TownID = 4;

            //Find employee with last name Nakov and alter his address with the new one

            Employees employee = softUniContext.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Addresses = address;

            softUniContext.SaveChanges();

            var addresses = softUniContext.Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10)
                .ToList();

            foreach (var currAddress in addresses)
            {
                Console.WriteLine(currAddress.Addresses.AddressText);
            }
        }
    }
}
