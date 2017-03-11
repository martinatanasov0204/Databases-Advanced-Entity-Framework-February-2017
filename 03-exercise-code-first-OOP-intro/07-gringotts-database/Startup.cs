namespace _07_gringotts_database
{
    using System;
    class Startup
    {
        static void Main()
        {
            var context = new GringottsContext();
            context.Database.Initialize(true);

            var wizzard = new WizardDeposits()
            {
                FirstName = "Albos",
                LastName = "Dumbledor",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false
            };

            context.Wizzards.Add(wizzard);

            context.SaveChanges();
        }
    }
}
