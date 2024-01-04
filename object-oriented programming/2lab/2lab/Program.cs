using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
    public partial class Customer
    {
        public readonly int idCustomer;
        private string surnameCustomer;
        private string nameCustomer;
        private string patronymicCustomer;
        private string adressOfCustomer;
        private string cardNumber;
        private double balanceCustomer;
        private static int countOfCustomers;
        private const int maxCustomers = 20;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer( "Быков", "Андрей", "Анатольевич", "ул. Кижеватова 1",
                "1234-5678-9876-5432", 123.3 );
            Customer customer3 = new Customer("Быков", "Андрей", "Анатольевич", "ул. Победителей 13",
                "1111-2222-3333-4444", 2.57 );
            Customer customer4 = new Customer("Романева", "Юлия", "Игнатова", "Московская область, г.Солнечногорск," + 
                "ул. Гистапова 34", "3668-3599-9639-2572", 234.87 );

            Console.WriteLine($"По умолчанию: {customer1} ");
            Console.WriteLine($"Заполненные объекты: \n{customer1} \n{customer2} \n{customer3} ");
            Console.WriteLine(customer2.GetType());

            Console.WriteLine($"ФИО первого заказчика: {customer2._surnameCustomer} {customer2._nameCustomer} " +
                $"{customer2._patronymicCustomer}");
            Console.WriteLine($"Адрес второго заказчика: {customer3._adressOfCustomer}");

            double differenceBalance = 321.34;
            customer2.DebitingMoney(ref differenceBalance);
            Console.WriteLine(differenceBalance);

            double difference;
            customer4.CreditingMoney(out difference);
            Console.WriteLine(difference);

            Console.WriteLine($"Равенство 1 и 2 заказчиков: {customer1.Equals(customer2)}");
            Console.WriteLine($"Равенство 2 и 3 заказчиков: {customer2.Equals(customer3)}");

            Customer.InputInformation();

            Customer[] customers = new Customer[] { new Customer("Трухан", "Игнат", "Валерьянович", "ул. Ковалёва 7", "1212-2323-3434-4545", 3), 
                new Customer("Лаптик", "Кирилл", "Оттович", "ул. Кишмяк", "2345-5432-2345-5432", 1234.63), 
                new Customer("Гультап", "Александр", "Кульбитов", "ул.Укропова", "1234-4321-2345-4321", 765.234),
                new Customer("Игнашенко", "Ольга", "Васильевна", "ул. Волковыса", "2345-7654-2345-9865", 12.34),
                new Customer("Укипр", "Танхат", "Титович", "ул. Подсолнухов", "2222-2222-2222-2222", 2222.2222)
            };

            Console.WriteLine("Отсортированный массив");
            Array.Sort(customers, (c1, c2) => c1._nameCustomer.CompareTo(c2._nameCustomer));
            for(int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine(customers[i]);
            }

            Console.WriteLine("\nЗаказчики с определённым балансом:");
            double minValue = 700;
            double maxValue = 1500;
            for(int i = 0; i < customers.Length; i++)
            {
                if (customers[i]._balanceCustomer >= minValue && customers[i]._balanceCustomer <= maxValue)
                {
                    Console.WriteLine(customers[i]);
                }
            }

            var anonymCustomer = new { _id = 3123124, _surnameCustomer = "Кажин", _nameCustomer = "Илья", _patronymicCustomer = "Артёмович", _adressOfCustomer = "ул. Пригожина", _cardNumber = "7777-7777-7777-7777", _balanceCustomer = 7777.7777};
            Console.WriteLine("\nВывод анонимного типа:");
            Console.WriteLine($"{anonymCustomer._id}\n" +
                $"{anonymCustomer._surnameCustomer}\n" +
                $"{anonymCustomer._nameCustomer}\n" +
                $"{anonymCustomer._patronymicCustomer}\n" +
                $"{anonymCustomer._adressOfCustomer}\n" +
                $"{anonymCustomer._cardNumber}\n" +
                $"{anonymCustomer._balanceCustomer}");
           /* Object obj = new Object();*/
        }
    }
}
