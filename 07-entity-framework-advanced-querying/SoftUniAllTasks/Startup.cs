namespace SoftUniAllTasks
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var context = new SoftUniContext();

            // 18-employees-maximum-salaries
            EmployeesMaxSalaries(context);
        }

        public static void EmployeesMaxSalaries(SoftUniContext context)
        {
            foreach (var department in context.Departments)
            {
                var maxSalary = department.Employees1
                    .Where(e => e.Departments1.Name == department.Name)
                    .Max(e => e.Salary);

                if (maxSalary < 30000 || maxSalary > 70000)
                {
                    Console.WriteLine("{0} - {1}", department.Name, maxSalary);
                }
            }
        }
    }
}
