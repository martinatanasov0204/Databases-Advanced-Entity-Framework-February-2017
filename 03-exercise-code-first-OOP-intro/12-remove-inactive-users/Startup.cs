namespace _12_remove_inactive_users
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            var context = new UsersContext();
            var filteredUsers = context.Users.Where(u => u.LastTimeLoggedIn < date);
            int count = 0;

            foreach (Users user in filteredUsers)
            {
                user.IsDeleted = true;
                count += 1;

            }

            if (count == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else
            {
                Console.WriteLine("{0} users have been deleted", count);
            }

            context.SaveChanges();
        }
    }
}
