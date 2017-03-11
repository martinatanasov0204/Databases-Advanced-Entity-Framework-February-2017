namespace _05_sales_migration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? Customer_Id { get; set; }

        public int? Product_Id { get; set; }

        public int? StoreLocation_Id { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual Products Products { get; set; }

        public virtual StoreLocations StoreLocations { get; set; }
    }
}
