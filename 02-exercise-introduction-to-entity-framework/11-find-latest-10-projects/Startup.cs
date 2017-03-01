namespace _11_find_latest_10_projects
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

            //Filter projects

            var projects = softUniContext.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                //Print each project details

                Console.WriteLine("{0} {1} {2:M/d/yyyy h:mm:ss tt} {3:M/d/yyyy h:mm:ss tt}", 
                    project.Name, 
                    project.Description, 
                    project.StartDate,
                    project.EndDate);
            }
        }
    }
}
