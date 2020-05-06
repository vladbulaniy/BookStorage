using Newtonsoft.Json;
using System;

namespace BookStorage
{
    class Program
    {
        public delegate void Add(Book Book);
        public delegate void Delete(int id);
        public delegate string FullName(Book book);


        static void Main(string[] args)
        {
            FullName fullName = HandleBook.DoFullName;

            Book newBook = new Book
            {
                Id = 10,
                Title = "Winnie-the-Pooh",
                Author = "Alan Alexander Milne"
            };
            Book2 book2 = new Book2();

            CustomMapper.Map(newBook, book2).ForMember(b => b.FullName = b.Title + b.Author);


            Console.WriteLine("Book1 - {0}", JsonConvert.SerializeObject(newBook));
            Console.WriteLine("Book2 - {0}", JsonConvert.SerializeObject(book2));
            Console.ReadLine();


            Add AddBook = HandleBook.AddBook;
            Delete DeleteBook = HandleBook.DeleteBook;
            

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
