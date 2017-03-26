namespace _02_advanced_mapping
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using _02_advanced_mapping.Classes;
    class Startup
    {
        static void Main()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<Employee, ManagerDTO>();
            });

            var employee = new Employee()
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Salary = 4000,
                Manager = new Employee()
                {
                    FirstName = "ManagerName",
                    LastName = "ManagerLastName"
                }
            };

            employee.Manager.ManagerOf.Add(new Employee()
            {
                FirstName = "Emp1",
                LastName = "EmpLastName1",
                Salary = 5431
            });

            ManagerDTO manager = Mapper.Map<ManagerDTO>(employee.Manager);

            Console.WriteLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.ManagerOf.Count}");
        }

        public class EmployeeDTO
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public decimal Salary { get; set; }
        }
        public class ManagerDTO
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<EmployeeDTO> ManagerOf { get; set; }
        }
    }
}
