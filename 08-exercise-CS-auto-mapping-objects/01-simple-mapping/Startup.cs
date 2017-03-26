namespace _01_simple_mapping
{
    using System;
    using AutoMapper;
    class Startup
    {
        static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

            var emp = new Employee()
            {
                FirstName = "Pesho",
                LastName =  "Petrov",
                Salary = 5000.12m,
                BirthDate = new DateTime(2016, 12, 12)
            };

            var empDTO = Mapper.Map<EmployeeDTO>(emp);

            Console.WriteLine(empDTO.FirstName);
            Console.WriteLine(empDTO.LastName);
            Console.WriteLine(empDTO.Salary);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
    }

    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
