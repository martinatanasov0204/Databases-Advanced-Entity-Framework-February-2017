namespace _04_students
{
    using System;
    class Startup
    {
        static void Main()
        {
            var name = Console.ReadLine();
            Students students = new Students(name);

            while (name!="End")
            {
                name = Console.ReadLine();
                students = new Students(name);
            }

            Console.WriteLine(Students.Count);
        }
    }
}
