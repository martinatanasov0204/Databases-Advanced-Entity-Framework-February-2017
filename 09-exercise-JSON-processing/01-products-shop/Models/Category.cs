namespace _01_products_shop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
