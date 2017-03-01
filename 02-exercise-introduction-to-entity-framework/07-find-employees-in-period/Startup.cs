namespace _07_find_employees_in_period
{
    using System.Threading;
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var softUniContext = new SoftUniContext();

            //Filter employees

            var employees = softUniContext.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Take(30);

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1} {2}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Employees2.FirstName);

                //Get projects

                var projects = employee.Projects;

                foreach (var project in projects)
                {
                    Console.WriteLine("--{0} {1:M/d/yyyy h:mm:ss tt} {2:M/d/yyyy h:mm:ss tt}", 
                        project.Name,
                        project.StartDate,
                        project.EndDate);
                }
            }
        }
    }
}
