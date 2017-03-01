namespace _13_find_employees_by_first_name_starting_with_SA
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
                .Where(e => e.FirstName.Substring(0, 2) == "SA");

            foreach (var employee in employees)
            {
                //I've updated the database twice at the previous task, so the results for Judge won't be correct

                Console.WriteLine("{0} {1} - {2} (${3})", employee.FirstName, employee.LastName, employee.JobTitle, employee.Salary);
            }
        }
    }
}
