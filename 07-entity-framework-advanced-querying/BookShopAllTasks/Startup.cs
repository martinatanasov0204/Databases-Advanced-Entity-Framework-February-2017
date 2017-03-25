namespace BookShopAllTasks
{
    using System;
    using System.Linq;
    using System.Data;
    using System.Data.SqlClient;
    class Startup
    {
        static void Main()
        {
            var context = new BookSystemContext();
            // 01-books-titles-by-age-restriction
            BookTitlesByAgeRestr(context);

            // 02-golden-books
            GoldenBooks(context);

            // 03-books-by-price
            BooksByPrice(context);

            // 04-not-released-books
            NotReleasedBooks(context);

            // 05-book-titles-by-category
            BookTitlesByCategory(context);

            // 06-books-released-before-date
            BooksReleasedBeforeDate(context);

            // 07-authors-search
            AuthorsSearch(context);

            // 08-books-search
            BooksSearch(context);

            // 09-book-titles-search
            BookTitlesSearch(context);

            // 10-count-books
            CountBooks(context);

            // 11-total-book-copies
            TotalBookCopies(context);

            // 12-find-profit
            FindProfit(context);

            // 13-most-recent-books
            MostRecentBooks(context);

            // 14-increase-book-copies
            IncreaseBookCopies(context);

            // 15-remove-books
            RemoveBooks(context);

            // 16-stored-procedure
            StoredProcedure(context);
        }

        private static void BookTitlesByAgeRestr(BookSystemContext context) // 01
        {
            var input = Console.ReadLine().ToLower();

            var query = "SELECT Title FROM Book WHERE AgeRestriction = {0}";

            var titles = context.Database.SqlQuery<string>(query, input).ToList();

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void GoldenBooks(BookSystemContext context) // 02
        {
            var query = "SELECT Title FROM Book WHERE EditionType = 'golden' AND Copies < 5000";

            var titles = context.Database.SqlQuery<string>(query);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static void BooksByPrice(BookSystemContext context) // 03
        {
            var query = "SELECT Title, Price FROM Book WHERE Price < 5 OR Price > 45";

            var data = context.Database.SqlQuery<Book>(query);

            foreach (var each in data)
            {
                Console.WriteLine("{0} - ${1:F2}", each.Title, each.Price);
            }
        }

        private static void NotReleasedBooks(BookSystemContext context) // 04
        {
            var inputYear = int.Parse(Console.ReadLine());

            var query = "SELECT Title FROM Book WHERE YEAR(ReleaseDate) <> {0}";

            var data = context.Database.SqlQuery<string>(query, inputYear);

            foreach (var each in data)
            {
                Console.WriteLine(each);
            }
        }

        private static void BookTitlesByCategory(BookSystemContext context) // 05
        {
            var categories = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse) // My database is with wrong parameters and that's why i use integer
               .ToList();
            var query = "SELECT * FROM Book";

            var books = context.Database.SqlQuery<Book>(query);

            foreach (var book in books)
            {
                if (categories.Contains(book.EditionType))
                {
                    Console.WriteLine(book.Title);
                }
            }
        } 

        private static void BooksReleasedBeforeDate(BookSystemContext context) // 06
        {
            var date = DateTime.Parse(Console.ReadLine());

            var query = "SELECT * FROM Book WHERE ReleaseDate < {0}";

            var books = context.Database.SqlQuery<Book>(query, date);

            foreach (var book in books)
            {
                // Again - my database is with wrong parameters and that's why edition type is integer

                Console.WriteLine("{0} {1} - {2:F2}", book.Title, book.EditionType, book.Price);
            }
        } 

        private static void AuthorsSearch(BookSystemContext context) // 07 
        {
            var regex = Console.ReadLine();

            var query = "SELECT * FROM Author";

            var authors = context.Database.SqlQuery<Author>(query);

            foreach (var author in authors)
            {
                var authorFirstName = author.FirstName;

                if (authorFirstName.Substring(authorFirstName.Length - regex.Length, regex.Length) == regex)
                {
                    Console.WriteLine("{0} {1}", author.FirstName, author.LastName);
                }
            }
        }

        private static void BooksSearch(BookSystemContext context) // 08 
        {
            var regex = Console.ReadLine().ToLower();

            var query = "SELECT Title FROM Book";

            var titles = context.Database.SqlQuery<string>(query).ToList();

            foreach (var title in titles)
            {
                if (title.ToLower().Contains(regex))
                {
                    Console.WriteLine(title);
                }
            }
        }

        private static void BookTitlesSearch(BookSystemContext context) // 09
        {
            var regex = Console.ReadLine().ToLower();

            var books = context.Book
                .Where(a => a.Author.LastName.ToLower().StartsWith(regex))
                .OrderBy(b => b.Id);

            foreach (var title in books)
            {
                Console.WriteLine("{0} ({1} {2})", title.Title, title.Author.FirstName, title.Author.LastName);
            }
        }

        private static void CountBooks(BookSystemContext context) // 10
        {
            var regex = int.Parse(Console.ReadLine());

            var query = @"SELECT Title FROM Book";

            var titles = context.Database.SqlQuery<string>(query);

            int count = 0;

            foreach (var title in titles)
            {
                if (title.Length > regex)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private static void TotalBookCopies(BookSystemContext context) // 11
        {
            var authors = context.Author
                    .OrderByDescending(a => a.Book.Sum(b => b.Copies))
                    .Select(a => new { Name = a.FirstName + " " +  a.LastName, Sum = a.Book.Sum(b => b.Copies)});

            foreach (var author in authors)
            {
                Console.WriteLine("{0} - {1}", author.Name, author.Sum);
            }
        }

        private static void FindProfit(BookSystemContext context) // 12
        {
            var categories = context.Category
                .OrderByDescending(c => c.Book.Sum(b => b.Copies * b.Price))
                .ThenBy(c => c.Name)
                .Select(c => new { Name = c.Name, Profit = c.Book.Sum(b => b.Copies * b.Price) });
            foreach (var category in categories)
            {
                Console.WriteLine("{0} - ${1}", category.Name, category.Profit);
            }
        }

        private static void MostRecentBooks(BookSystemContext context) // 13
        {
            var categories = context.Category
                .Where(c => c.Book.Count > 35)
                .OrderByDescending(c => c.Book.Count);

            foreach (var category in categories)
            {
                Console.WriteLine("--{0}: {1} books", category.Name, category.Book.Count);

                foreach (var book in category.Book.OrderByDescending(b => b.ReleaseDate).ThenBy(b => b.Title).Take(3))
                {
                    Console.WriteLine("{0} ({1})", book.Title, book.ReleaseDate.Year);
                }
            }
        }

        private static void IncreaseBookCopies(BookSystemContext context) // 14
        {
            int count = 0;

            foreach (var book in context.Book.Where(b => b.ReleaseDate > DateTime.Parse("06-06-2013")))
            {
                book.Copies += 44;
                count += 44;
            }

            Console.WriteLine(count);

            context.SaveChanges();
        }

        private static void RemoveBooks(BookSystemContext context)
        {
            int count = 0;

            foreach (var book in context.Book.Where(b => b.Copies < 4200))
            {
                context.Book.Remove(book);
                count += 1;
            }
            Console.WriteLine("{0} books were deleted", count);

            context.SaveChanges();
        } // 15

        private static void StoredProcedure(BookSystemContext context) // 16
        {
            string[] name = Console.ReadLine()
                .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            SqlParameter firstName = new SqlParameter("@firstName", name[0]);
            SqlParameter secondName = new SqlParameter("@lastName", name[1]);
            SqlParameter result = new SqlParameter();
            result.ParameterName = "@result";
            result.Direction = ParameterDirection.Output;
            result.SqlDbType = SqlDbType.Int;

            context.Database.ExecuteSqlCommand("execute Author_Books  @firstName, @lastName ,@result output",
                                                                         result, firstName, secondName);

            Console.WriteLine($"{firstName.Value} {secondName.Value} has written {result.Value} books");

            // CREATE PROCEDURE Author_Books @FirstName nvarchar(max), @LastName nvarchar(max), @result int out
            // AS
            // BEGIN
            // SET @result = (SELECT COUNT(b.Id) FROM Author AS a
            // JOIN Book AS b
            // ON a.Id = b.AuthorId
            // WHERE a.FirstName = @FirstName AND a.LastName = @LastName
            // GROUP BY AuthorId)
            // END
            // GO
        }
    }
}
