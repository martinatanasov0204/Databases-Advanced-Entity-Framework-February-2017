namespace _03_oldest_family_member
{
    using System;
    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family fam = new Family();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];
                int age = int.Parse(line[1]);

                fam.AddMember(new Person(name, age));
            }

            Person oldestOne = fam.GetOldestPerson();

            Console.WriteLine("{0} {1}", oldestOne.Name, oldestOne.Age);
        }
    }
}
