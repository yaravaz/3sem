using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab17_18
{
    public interface IReader
    {
        void GetTicket();
        void GetStatus();
    }
    public class ResentReader : IReader
    {
        public string Id { get; set; }
        public string FIO { get; set; }
        public double Money { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active = false;
        public bool Registered = false;
        public bool HasTicket = false;

        public ResentReader(string id, string fio, double money, string login, string password)
        {
            Id = id;
            FIO = fio;
            Money = money;
            Login = login;
            Password = password;
        }

        public void GetTicket()
        {
            if (HasTicket)
            {
                WriteLine("У читателя уже есть абонемент? Серьёзно?");
            }
            else
            {
                HasTicket = true;
                WriteLine("Читатель приобрёл абонемент");
            }
        }
        public void GetStatus() => WriteLine("Это новый клиент");
    }

    public class RegularReader : IReader
    {
        public string Id { get; set; }
        public string FIO { get; set; }
        public double Money { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active = false;
        public bool Registered = false;
        public bool HasTicket = false;

        public RegularReader(string id, string fio, double money, string login, string password)
        {
            Id = id;
            FIO = fio;
            Money = money;
            Login = login;
            Password = password;
        }

        public void GetTicket()
        {
            if (HasTicket)
            {
                WriteLine("У читателя уже есть абонемент! Он никогда не заканчивается");
            }
            else
            {
                HasTicket = true;
                WriteLine("Читатель приобрёл абонемент");
            }
        }
        public void GetStatus() => WriteLine("Это постоянный клиент");
    }

    public interface IReaderFactory
    {
        IReader CreateResentReader();
        IReader CreateRegularReader();
    }

    class ReaderFactory : IReaderFactory
    {
        public IReader CreateResentReader()
        {
            return new ResentReader("1QV4", "QWE", 12.3, "qwertx", "qwertx");
        }
        public IReader CreateRegularReader()
        {
            return new ResentReader("1QK0", "UIR", 1234.3, "qwertz", "qwertz");
        }
    }
}
