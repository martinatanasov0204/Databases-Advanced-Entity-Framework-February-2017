namespace _02_car_dealer.Models
{
    using System;
    using System.Collections.Generic;
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
