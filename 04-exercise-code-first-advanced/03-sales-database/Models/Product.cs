namespace _03_sales_database.Models
{
    using System.Collections.Generic;
    public class Product
    {
        public Product()
        {
            SalesOfProduct = new List<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public ICollection<Sale> SalesOfProduct { get; set; }
    }
}
