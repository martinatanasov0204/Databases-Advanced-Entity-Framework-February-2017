namespace _01_products_shop.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class User
    {
        public User()
        {
            ProductsSold = new HashSet<Product>();
            ProductsBought = new HashSet<Product>();
            Friends = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Product> ProductsSold { get; set; }
        public virtual ICollection<Product> ProductsBought { get; set; }
        public virtual ICollection<User> Friends { get; set; }
    }
}
