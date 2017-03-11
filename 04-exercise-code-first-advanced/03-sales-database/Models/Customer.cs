namespace _03_sales_database.Models
{
    using System.Collections.Generic;
    public class Customer
    {
        public Customer()
        {
            SalesOfCustomer = new List<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public ICollection<Sale> SalesOfCustomer { get; set; }

    }
}
