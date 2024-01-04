using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18
{
    public class Order
    {

        List<Book> order = new List<Book>();

        public double CalcPrice()
        {
            double sum = 0;
            foreach (var book in order)
            {
                sum+= book.Price;  
            }
            return sum;
        }

        public void AddBook(Book book)
        {
            if(book.Quantity != 0)
            {
                order.Add(book);
                book.Quantity--;
                WriteLine("Книга добавлена в заказ");
            }
            else
            {
                WriteLine("Нет столько книг");
            }
        }

        public void RemoveBook(Book book)
        {
            if (order.Contains(book))
            {
                order.Remove(book);
                book.Quantity++;
                WriteLine("Книга убрана из заказа");
            }
            else
            {
                WriteLine("Книги нет в заказе");
            }
        }
    }
}
