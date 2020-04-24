using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookStorage
{
    public class HandleBook
    {
        static List<Book> Books = new List<Book> {
            new Book
            {
                Id = 1,
                Title = "A Christmas Carol",
                Author = "Charles Dickens"
            },
            new Book
            {
                Id=2,
                Title = "Jane Eyre",
                Author = "Charlotte Bronte"
            },
            new Book
            {
                Id = 3,
                Title = "Bridget Jones' Diary",
                Author = "Helen Fielding"
            }
        };

        public delegate void BookHandler(string message);
        public static event BookHandler Notify;

        public static void AddBook(Book book)
        {
            if (book.Id == 0)
            {
                book.Id = Books.Last().Id +1;
            }
            Books.Add(book);
            Notify?.Invoke($"The name of added book is {book.Title}");
        }

        public static void DeleteBook(int bookId)
        {
            string result = "Book doesnt find";
            var book = Books.SingleOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                result = book.Title;
                Books.Remove(book);                
            }
            result = $"The name of deleted book is {book.Title}";
            Notify?.Invoke(result);
        }

        public static string GetAllBooks()
        {
            return JsonConvert.SerializeObject(Books);
            
        }
    }
}
