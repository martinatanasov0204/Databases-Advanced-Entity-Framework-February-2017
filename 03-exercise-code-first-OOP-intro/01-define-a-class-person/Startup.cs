namespace _01_define_a_class_person
{
    class Startup
    {
        static void Main()
        {
            Person person1 = new Person()
            {
                Name = "Pesho",
                Age = 20
            };

            Person person2 = new Person()
            {
                Name = "Gosho",
                Age = 18
            };

            Person person3 = new Person()
            {
                Name = "Stamat",
                Age = 43
            };
        }
    }
}
