namespace _10_departments_with_more_than_5_employees
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Filter departments

            var departments = softUniContext.Departments
                .Where(d => d.Employees1.Count > 5)
                .OrderBy(e => e.Employees1.Count)
                .ToList();

            foreach (var department in departments)
            {
                var managerName = department.Employees.FirstName;

                Console.WriteLine("{0} {1}", department.Name, managerName);

                //Print all employees from each department

                foreach (var employee in department.Employees1)
                {
                    Console.WriteLine("{0} {1} {2}", employee.FirstName, employee.LastName, employee.JobTitle);
                }
            }
        }
    }
}
