namespace _03_sales_database
{
    class Startup
    {
        static void Main()
        {
            var context = new SalesContext();
            context.Database.Initialize(true);
        }
    }
}
