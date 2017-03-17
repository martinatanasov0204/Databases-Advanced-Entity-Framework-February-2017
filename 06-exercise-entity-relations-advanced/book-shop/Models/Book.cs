namespace _01_book_shop_system_DB.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }
    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }
    public class Book
    {
        public Book()
        {
            Categories = new HashSet<Category>();
            RelatedBooks = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EditionType EditionType { get; set; }
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public AgeRestriction AgeRestriction { get; set; }
        public DateTime ReleaseDate { get; set; }
        [ForeignKey("AtuAuthor")]
        public virtual int AuthorId { get; set; }

        public virtual Author AtuAuthor { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Book> RelatedBooks { get; set; }

    }
}          
        

