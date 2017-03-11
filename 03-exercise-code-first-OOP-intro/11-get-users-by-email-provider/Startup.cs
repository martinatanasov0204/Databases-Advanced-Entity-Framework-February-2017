namespace _11_get_users_by_email_provider
{
    using System;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var context = new UsersContext();

            var user = new Users()
            {
                Username = "GeshaMecha",
                Password = "Ab1!423543",
                Email = "loshi_kz-123@bek.bg",
                RegisteredOn = new DateTime(2016, 2, 4),
                LastTimeLoggedIn = new DateTime(2017, 1, 3),
                Age = 14,
                IsDeleted = true
            };

            //context.Users.Add(user);

            foreach (var item in context.Users.Where(u => u.Email.Contains(input)))
            {
                Console.WriteLine(item.Email);
            }

            context.SaveChanges();
        }
    }
}
