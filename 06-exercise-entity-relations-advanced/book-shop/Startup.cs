namespace _01_book_shop_system_DB
{
    class Startup
    {
        static void Main()
        {
            var context = new BookSystemContext();
            context.Database.Initialize(true);
        }
    }
}
