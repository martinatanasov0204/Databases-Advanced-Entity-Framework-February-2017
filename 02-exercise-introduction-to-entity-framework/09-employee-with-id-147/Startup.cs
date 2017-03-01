namespace _09_employee_with_id_147
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Get the employee with Id - 147

            var employee = softUniContext.Employees
                .Find(147);

            var projects = employee.Projects
                .OrderBy(p => p.Name)
                .ToList();

            Console.WriteLine("{0} {1} {2} ", employee.FirstName, employee.LastName, employee.JobTitle);

            //Print all project names from this employee

            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
            }
        }
    }
}
