namespace _03_employees_full_information
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Filter employees

            var employees = softUniContext.Employees
                .OrderBy(e => e.EmployeeID)
                .Select(e => new { e.FirstName, e.MiddleName, e.LastName, e.JobTitle, e.Salary})
                .ToArray();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", 
                                    employee.FirstName, 
                                    employee.LastName, 
                                    employee.MiddleName, 
                                    employee.JobTitle, 
                                    employee.Salary);
            }
        }
    }
}
