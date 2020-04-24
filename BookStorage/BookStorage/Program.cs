using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    class Program
    {
        public delegate void Add(Book Book);
        public delegate void Delete(int id);


        static void Main(string[] args)
        {
            Add AddBook = HandleBook.AddBook;
            Delete DeleteBook = HandleBook.DeleteBook;
            Book newBook = new Book
            {
                Title = "Winnie-the-Pooh",
                Author = "Alan Alexander Milne"
            };

            HandleBook.Notify += DisplayMessage;

            AddBook(newBook);
            Console.WriteLine();
            Console.WriteLine("All books - {0}", HandleBook.GetAllBooks());
            Console.WriteLine();
            DeleteBook(2);
            Console.WriteLine();
            Console.WriteLine("All books - {0}", HandleBook.GetAllBooks());
            Console.ReadLine();           
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
