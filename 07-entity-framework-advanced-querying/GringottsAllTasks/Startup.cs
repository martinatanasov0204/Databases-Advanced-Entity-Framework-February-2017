namespace GringottsAllTasks
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var context = new GringottsContext();

            // 19-deposits-sum-for-ollivander-family
            DepositSumForOllivanderFamily(context);

            // 20-deposits-filter
            DespositsFilter(context);
        }

        public static void DepositSumForOllivanderFamily(GringottsContext context) // 19
        {
            var groups = context.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select(w => new { Name = w.Key, Sum = w.Sum(wd => wd.DepositAmount) });

            foreach (var group in groups)
            {
                Console.WriteLine("{0} - {1}", group.Name, group.Sum);
            }
        }
        private static void DespositsFilter(GringottsContext context) // 20
        {
            var groups = context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)
                .Select( w => new { Name = w.Key, Sum = w.Sum(wd => wd.DepositAmount) })
                .OrderByDescending(w => w.Sum);

            foreach (var group in groups)
            {
                if (group.Sum < 150000)
                {
                    Console.WriteLine("{0} - {0}", group.Name, group.Sum);
                }
            }
        }
    }
}
