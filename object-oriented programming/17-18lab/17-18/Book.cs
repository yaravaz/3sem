using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17_18
{
    public partial class Book
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Book() { }
        public Book(double price, string name, string author, int quantity)
        {
            Price = price;
            Name = name;
            Author = author;
            Quantity = quantity;
        }

/*        public static void NewBook(Book book)
        {
            foreach (var item in books)
            {
                if (item.Name == book.Name)
                {
                    item.Quantity += book.Quantity;
                    break;
                }
                else
                {
                    books.Add(item);
                    break;
                }
            }
        }*/
    }
}
