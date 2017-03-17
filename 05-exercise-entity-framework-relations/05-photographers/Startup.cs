namespace _05_photographers
{
    using System;
    class Startup
    {
        static void Main()
        {
            var context = new PhotographyContext();
            //context.Database.Initialize(true);

            var photographer = new Photographer()
            {
                Username = "pesho123",
                Password = "pesho456",
                Email = "pesho_kz@gmail.com",
                RegisterDate = new DateTime(2016, 10, 12),
                Birthdate = new DateTime(1995, 4, 17)
            };

            var photographer2 = new Photographer()
            {
                Username = "leshoMesho",
                Password = "12345678900",
                Email = "kanzasBoy@gmail.com",
                RegisterDate = new DateTime(2016, 5, 26),
                Birthdate = new DateTime(1998, 8, 14)
            };

            var photographer3 = new Photographer()
            {
                Username = "baiGanio",
                Password = "ganioBalkanski",
                Email = "naZapovqdai@gmail.com",
                RegisterDate = new DateTime(2017, 2, 6),
                Birthdate = new DateTime(1990, 11, 9)
            };

            context.Photographers.Add(photographer);
            context.Photographers.Add(photographer2);
            context.Photographers.Add(photographer3);

            context.SaveChanges();
        }
    }
}
