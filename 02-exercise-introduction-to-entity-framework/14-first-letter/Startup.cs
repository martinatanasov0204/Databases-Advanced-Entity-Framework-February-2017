namespace _14_first_letter
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var grigottsContext = new GrigottsContext();

            //Filter unique wizzards and get the first letter of their first name

            var uniqueWizzards = grigottsContext.WizzardDeposits
                .Where(e => e.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName.Substring(0, 1))
                .Distinct()
                .OrderBy(w => w);

            foreach (var uniqueWizzardLetter in uniqueWizzards)
            {
                Console.WriteLine(uniqueWizzardLetter);
            }
        }
    }
}
