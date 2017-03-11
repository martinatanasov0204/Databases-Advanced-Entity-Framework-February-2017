namespace _02_create_person_constructors
{
    using System;
    class Startup
    {
        static void Main()
        {
            var inputParams = Console.ReadLine();

            Person person = new Person();
            
            if (inputParams.Length == 0)
            {
                person = new Person();
            }
            else
            {
                var parts = inputParams.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 1)
                {
                    int age;
                    bool isNumeric = int.TryParse(parts[0], out age);

                    if (isNumeric)
                    {
                        person = new Person()
                        {
                            Age = age
                        };
                    }
                    else
                    {
                        person = new Person()
                        {
                            Name = parts[0]
                        };
                    }
                }
                else
                {
                    person = new Person()
                    {
                        Name = parts[0],
                        Age = int.Parse(parts[1])
                    };
                }
            }

            Console.WriteLine("{0} {1}", person.Name, person.Age);
        }
    }
}
