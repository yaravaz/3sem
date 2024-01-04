using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18

{
    public interface IMovementBook
    {
        Book ToBook(List<Book> list);
    }

    public class WrapperOverIMovementBook : IMovementBook
    {
        public Book ToBook(List<Book> list)
        {
            WriteLine("Список книг");
            foreach(Book item in list)
            {
                WriteLine($"{item.Name} {item.Author}");
            }
            WriteLine("Названиеи и цена книги: ");
            string name = ReadLine();
            string author = ReadLine();
            double price = Convert.ToDouble(ReadLine());
            int quantity = Convert.ToInt32(ReadLine());
            Book book = new Book(price, name, author, quantity);
            WriteLine(book);

            return book;
        }
    }

    public interface IMovable
    {
        void Move();
    }
    public class SerchingForBook : IMovable
    {
        public void Move() => WriteLine("Я ищу книгу");
    }
    public class FindedBook : IMovable
    {
        public void Move() => WriteLine("Найдена подходящая книга");
    }

    public class Reader : WrapperOverIMovementBook, IMovable
    {
        public string Name {  get; set; }
        public string Id { get; set; }
        public bool Active = false;
        public bool Registered = false;
        public bool HasTicket = false;
        public string Login { get; set; }
        public string Password { get; set; }
        public IMovable Movable { private get; set; }

        public Reader(string name, IMovable movable)
        {
            Movable = movable;
            Name = name;
        }
        public void Move() => Movable.Move();

        // Singleton

        private static Reader special;
        private Reader(string name) => Name = name;
        public static Reader GetInstance(string name)
        {
            if(special == null)
            {
                special = new Reader(name);
            }
            return special;
        }


        // State
        public enum States
        {
            Registration,
            Find,
            Paying
        }
        public States State { get; set; }
        public Reader(States state) => State = state;

        public void Go()
        {
            if(State == States.Registration)
            {
                WriteLine($"Читатель зарегистрировался");
                State = States.Registration;
            }
            else if(State == States.Find)
            {
                WriteLine($"Читатель ищет книгу");
                State = States.Find;
            }
            else if(State == States.Paying)
            {
                WriteLine($"Читатель опаливает книгу");
                State = States.Paying;
            }
        }
        public void Stop()
        {
            if (State == States.Find)
            {
                WriteLine($"Читатель нашёл книгу");
                State = States.Find;
            }
            else if( State == States.Paying)
            {
                WriteLine($"Читатель закончил оплату и вышел из системы");
                State = States.Paying;
            }
        }
    }

    public class Librarian
    {
        public static void Pay(Book book)
        {
            WriteLine($"Цена книги: {book.Price}");
        }
    }

    public class System
    {
        static List<Reader> readers = new List<Reader>();

        public static void RegisterReader(Reader reader)
        {
            if (!reader.Registered)
            {
                reader.Registered = true;
                WriteLine("Регистрация проведена успешна");
            }
            else
            {
                WriteLine("Читатель уже зарегестрирован");
            }
        }

        public static void LogOut(Reader reader)
        {
            if (reader.Active)
            {
                reader.Active = false;
                WriteLine("Читатель вышел из системы");
            }
            else
            {
                WriteLine("Читатель не в системе");
            }
        }
        public static void LogIn(Reader reader, string login, string password)
        {
            if (!reader.Active)
            {
                if(reader.Login == login && reader.Password == password)
                {
                    reader.Active = true;
                    WriteLine("Читатель вошёл в систему");
                }
                else
                {
                    WriteLine("Данные некорректны");
                }
            }
            else
            {
                WriteLine("Читатеть в системе");
            }
        }
        public static void CheckingOut(string id)
        {
            foreach (var reader in readers)
            {
                if(reader.Id == id)
                {
                    WriteLine("Такой читатель есть в системе");
                }
            }
        }

    }
}
