namespace _04_resource_licenses
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
