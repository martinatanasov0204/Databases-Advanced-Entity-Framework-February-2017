namespace _04_students
{
    class Students
    {       
        static private int Integer = 0;
        static public int Count { get { return Integer; } }
        public Students(string name)
        {
            this.Name = name;
            Integer++;
        }
        public string Name { get; set; }
    }
}
