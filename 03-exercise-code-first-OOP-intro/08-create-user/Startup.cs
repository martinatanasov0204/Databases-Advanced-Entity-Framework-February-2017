namespace _08_create_user
{
    using System;
    class Startup
    {
        static void Main()
        {
            var context = new UserContext();
            context.Database.Initialize(true);

            var user = new User()
            {
                Username = "Pesho123",
                Password = "Ab1@4444",
                Email = "ala-bala-123@portukala.com",
                RegisteredOn = new DateTime(2016, 12, 12),
                LastTimeLoggedIn = new DateTime(2017, 3, 8),
                Age = 28,
                IsDeleted = false
            };

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
