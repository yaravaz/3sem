using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Factory
            IReaderFactory factory = new ReaderFactory();

            IReader resentReader = factory.CreateResentReader();
            resentReader.GetStatus();
            IReader regularReader = factory.CreateRegularReader();
            regularReader.GetStatus();

            Book book1 = new Book(12.3, "Qwerty1", "Qwerty1", 3);
            Book book2 = new Book(4.3, "Qwerty2", "Qwerty2", 2);
            Book book3 = new Book(5.8, "Qwerty3", "Qwerty3", 1);
            Book book4 = new Book(9.34, "Qwerty4", "Qwerty4", 5);
            Book book5 = new Book(20.33, "Qwerty5", "Qwerty5", 10);

            List<Book> library = new List<Book>() { book1, book2, book3, book4, book5 };

            // Builder

            Builder builder = new CurrBuilder();
            Director director = new Director(builder);
            director.Construct(31.23, "temp", "temp", 2);
            Book res = builder.GetBook();

            Order order = new Order();

            order.AddBook(book1);
            order.AddBook(book3);
            order.AddBook(book3);
            order.CalcPrice();
            order.RemoveBook(book3);
            order.RemoveBook(book4);
            order.AddBook(book3);

            //Singleton
            Reader special = Reader.GetInstance("FNG");

            var current = special.ToBook(library);

            Librarian.Pay(current);

            //Prototype

            IPrototype oldBook = new Book();
            oldBook.SetBookGenre("Романтика");

            IPrototype newBook = oldBook.Clone();

            WriteLine(oldBook.GetGenreBook());
            WriteLine(newBook.GetGenreBook());

            //Adapter

            AReader aReader = new AReader();
            Genre genre = new Genre();
            aReader.Reading(genre);
            Article article = new Article();
            article.Learn();

            IGenre readArticle = new ArticleAdapter(article);
            aReader.Reading(readArticle);

            // Decorator

            Section section = new T();
            section = new Teen(section);
            Console.WriteLine($"Рейтинг: {section.AgeRating}");
            Console.WriteLine($"Возраст: {section.GetAge()}");

            // State

            Reader reader = new Reader(Reader.States.Registration);
            reader.Name = "Игорь";
            reader.Go();
            reader.Go();
            reader.Stop();

            // Command

            AnotherReader anotherReader = new AnotherReader();
            Reading reading = new Reading();
            anotherReader.SetCommand(new DoReadingCommand(reading));
            anotherReader.Go();
            anotherReader.Stoped();

        }
    }
}
