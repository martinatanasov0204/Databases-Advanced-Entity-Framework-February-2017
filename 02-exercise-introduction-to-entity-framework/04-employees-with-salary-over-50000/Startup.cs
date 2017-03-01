namespace _04_employees_with_salary_over_50000
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Filer employees

            var employees = softUniContext.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                Console.WriteLine("{0}", employee);
            }
        }
    }
}
