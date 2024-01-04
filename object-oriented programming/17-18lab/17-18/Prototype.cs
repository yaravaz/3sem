using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    public interface IPrototype
    {
        string GetGenreBook();
        void SetBookGenre(string bookName);

        IPrototype Clone();
    }


    partial class Book : IPrototype
    {
        public string Name { get; set; }
        public string Author { get; set; }

        public string BookGenre { get; set; }

        public static readonly List<Book> books = new List<Book>();
        public Book(string bookGenre, double price)
        {
            BookGenre = bookGenre;
            Price = price;
        }

        private Book(Book donor) => BookGenre = donor.BookGenre;
        public string GetGenreBook() => BookGenre;
        public void SetBookGenre(string bookGenre) => BookGenre = bookGenre;
        public IPrototype Clone() => new Book(this);
    }
}
