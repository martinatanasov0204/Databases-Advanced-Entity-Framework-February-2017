﻿namespace _02_car_dealer.Models
{
    using System.Collections.Generic;
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImporter { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
