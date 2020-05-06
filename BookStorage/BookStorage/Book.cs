using BookStorage.Attributes;

namespace BookStorage
{
    public class Book
    {
        [Ignore(true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string FullName { get; set; }
    }
}
