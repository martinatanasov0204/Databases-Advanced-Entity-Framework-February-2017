namespace _01_book_shop_system_DB.Models
{
    using System.Collections.Generic;
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
