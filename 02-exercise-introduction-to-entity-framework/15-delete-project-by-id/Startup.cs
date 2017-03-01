namespace _15_delete_project_by_id
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var softUniContext = new SoftUniContext();

            //Find project with Id - 2

            var project = softUniContext.Projects.Find(2);

            //Delete project from employees who reference it

            project.Employees.Clear();

            //Remove the project from database

            softUniContext.Projects.Remove(project);

            softUniContext.SaveChanges();

            var projectsToPrint = softUniContext.Projects
                .Select(p => p.Name)
                .Take(10);

            //Print projects names

            foreach (var item in projectsToPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
