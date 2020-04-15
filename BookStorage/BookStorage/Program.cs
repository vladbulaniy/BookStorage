using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    class Program
    {
        public delegate string Add(Book Book);
        public delegate string Delete(int id);


        static void Main(string[] args)
        {
            Add AddBook = HandleBook.AddBook;
            Delete DeleteBook = HandleBook.DeleteBook;
            Book newBook = new Book
            {
                Title = "Winnie-the-Pooh",
                Author = "Alan Alexander Milne"
            };
            Console.WriteLine("Lets add new book. This is {0}", AddBook(newBook));
            Console.WriteLine();
            Console.WriteLine("All books - {0}", HandleBook.GetAllBooks());
            Console.WriteLine();
            Console.WriteLine("Lets remove Jane Eyre book. The removed book title is {0}", DeleteBook(2));
            Console.WriteLine();
            Console.WriteLine("All books - {0}", HandleBook.GetAllBooks());
            Console.ReadLine();
        }
    }
}
