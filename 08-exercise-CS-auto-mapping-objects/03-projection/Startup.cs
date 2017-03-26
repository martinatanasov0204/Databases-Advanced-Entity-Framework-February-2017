namespace _03_projection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using _03_projection.Classes;
    class Startup
    {
        static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

            var employees = new List<Employee>();

            var employee = new Employee()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Salary = 4000,
                BirthDate = new DateTime(2005, 6, 7),
                Manager = new Employee()
                {
                    FirstName = "ManagerName",
                    LastName = "ManagerLastName"
                }
            };

            var employee2 = new Employee()
            {
                FirstName = "Hesho",
                LastName = "Heshev",
                Salary = 5555,
                BirthDate = new DateTime(1980, 10, 4),
                Manager = new Employee()
                {
                    FirstName = "HeshoManName",
                    LastName = "HeshoManLastName"
                }
            };

            employees.Add(employee);
            employees.Add(employee2);


            foreach (var emp in employees.Where(e => e.BirthDate.Year < 1990).OrderByDescending(e => e.Salary))
            {
                var empDTO = Mapper.Map<EmployeeDTO>(emp);

                Console.WriteLine($"{empDTO.FirstName} {empDTO.LastName} {empDTO.Salary} – Manager: {empDTO.ManagerLastName}");
            }
        }

        public class EmployeeDTO
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal Salary { get; set; }
            public string ManagerLastName { get; set; }
        }
    }
}
