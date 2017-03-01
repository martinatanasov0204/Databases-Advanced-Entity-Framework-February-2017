namespace _05_employees_from_seattle
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
                .Where(e => e.Departments1.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new { e.FirstName, e.LastName, e.Departments1.Name, e.Salary })
                .ToArray();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1} from {2} - ${3:F2}",
                                    employee.FirstName,
                                    employee.LastName,
                                    employee.Name,
                                    employee.Salary);
            }
        }
    }
}
