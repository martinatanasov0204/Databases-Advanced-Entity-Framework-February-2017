﻿namespace _02_create_person_constructors
{
    class Person
    {
        public Person() : this("No name", 1) { }

        public Person(int age) : this("No name", age) { }

        public Person(string name) : this(name, 1) { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
