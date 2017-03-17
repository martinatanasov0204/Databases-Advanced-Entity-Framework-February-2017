namespace _01_code_first_student_system
{
    class Startup
    {
        static void Main()
        {
            var context = new SchoolSystemContext();
            context.Database.Initialize(true);
        }
    }
}
