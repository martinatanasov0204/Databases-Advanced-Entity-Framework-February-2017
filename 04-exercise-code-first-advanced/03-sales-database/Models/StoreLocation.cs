namespace _03_sales_database.Models
{
    using System.Collections.Generic;
    public class StoreLocation
    {
        public StoreLocation()
        {
            SalesInStore = new List<Sale>();
        }
        public int Id { get; set; }
        public string LocationName { get; set; }

        public ICollection<Sale> SalesInStore { get; set; }
    }
}
