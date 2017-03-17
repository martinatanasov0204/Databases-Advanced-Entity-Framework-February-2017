namespace _03_working_with_the_database
{
    using System.Linq;
    using System;
    class Startup
    {
        static void Main()
        {
            //I'm sorry, but i didn't fill the tables with enough records

            var context = new SchoolSystemContext();
            EachStudent(context);
        }

        public static void ListAllStudents(SchoolSystemContext context)
        {
            foreach (var student in context.Students)
            {
                Console.WriteLine(student.Name);
                Console.WriteLine("-----------------");
                foreach (var homework in student.Homework)
                {
                    Console.WriteLine("{0} {1}", homework.Content, homework.ContentType);
                }
                Console.WriteLine("Next:");
                Console.WriteLine();
            }
        }
        public static void ListAllCourses(SchoolSystemContext context)
        {
            foreach (var resource in context.Resources)
            {
                Console.WriteLine("{0} {1} {2}", resource.Name, resource.TypeOfResource, resource.URL);
                Console.WriteLine("-----------------");
                foreach (var course in resource.Courses.OrderBy(c => c.StartDate).OrderByDescending(c => c.EndDate))
                {
                    Console.WriteLine("{0} {1}", course.Name, course.Description);
                }
                Console.WriteLine("Next:");
                Console.WriteLine();
            }
        }
        public static void ListAllCoursesWithMoreThan(SchoolSystemContext context)
        {
            foreach (var course in context.Courses.Where(c => c.Resources.Count > 5).OrderByDescending(r => r.Resources.Count).OrderBy(r => r.StartDate))
            {
                Console.WriteLine("{0} {1} {2}", course.Name, course.Description);
                Console.WriteLine("-----------------");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine("{0} {1}", resource.Name, resource.TypeOfResource);
                }
                Console.WriteLine("Next:");
                Console.WriteLine();
            }
        }
        public static void EachStudent(SchoolSystemContext context)
        {
            foreach (var student in context.Students)
            {
                decimal totalPrice = 0;
                Console.Write(student.Name + " ---> ");
                foreach (var course in student.Courses)
                {
                    totalPrice += course.Price;
                }
                Console.WriteLine("{0} | {1:F2}", totalPrice, totalPrice / student.Courses.Count);
            }
        }

    }
}
