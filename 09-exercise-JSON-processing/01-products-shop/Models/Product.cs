namespace _01_products_shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public User Seller { get; set; }
        public int? BuyerId { get; set; }
        public User Buyer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; set; }
    }
}
