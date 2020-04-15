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

        public static string AddBook(Book book)
        {
            if (book.Id == 0)
            {
                book.Id = Books.Last().Id +1;
            }
            Books.Add(book);
            return book.Title;
        }

        public static string DeleteBook(int bookId)
        {
            string result = "Book doesnt find";
            var book = Books.SingleOrDefault(x => x.Id == bookId);
            if (book != null)
            {
                result = book.Title;
                Books.Remove(book);                
            }
            return result;
        }

        public static string GetAllBooks()
        {
            return JsonConvert.SerializeObject(Books);
            
        }
    }
}
