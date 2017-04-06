namespace _02_car_dealer.Models
{
    using System.Collections.Generic;
    public class Car
    {
        public Car()
        {
            Parts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
