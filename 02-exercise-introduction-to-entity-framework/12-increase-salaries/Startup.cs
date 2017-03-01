namespace _12_increase_salaries
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
                .Where(e => e.Departments1.Name == "Engineering"
                            || e.Departments1.Name == "Tool Design"
                            || e.Departments1.Name == "Marketing"
                            || e.Departments1.Name == "Information Services");

            foreach (var employee in employees)
            {
                //Increase salaries by 12% and print results

                var currSalary = employee.Salary;
                employee.Salary = currSalary * (decimal)(0.12) + currSalary;

                Console.WriteLine("{0} {1} (${2}) ", employee.FirstName, employee.LastName, employee.Salary);
            }
            
            //Save changes

            softUniContext.SaveChanges();
        }
    }
}
