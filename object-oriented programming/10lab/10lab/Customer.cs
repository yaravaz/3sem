using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _10lab
{
    internal class Customer
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public int CardNumber { get; set; }
        public double Balance { get; set; }

        public static int Count = 0;
        public Customer(string surname, string name, int cardNumber, double balance)
        {
            Surname = surname;
            Name = name;
            CardNumber = cardNumber;
            Balance = balance;
            Count++;
        }
        public Customer()
        {
            Surname = "Undefined";
            Name = "Undefined";
            CardNumber = 0;
            Balance = 0;
            Count++;
        }
        public static void InputInformation()
        {
            Console.WriteLine("В этом класса хранятся:\n" +
                "ФИО заказчика \n" +
                "Номер карты заказчика\n" +
                "Баланс");
        }
        public override string ToString()
        {
            return $"{Surname} {Name} {CardNumber} {Balance}";

        }

    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerOr { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
