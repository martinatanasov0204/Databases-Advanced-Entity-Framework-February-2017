﻿namespace _02_car_dealer.Models
{
    using System.Collections.Generic;
    public class Part
    {
        public Part()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
