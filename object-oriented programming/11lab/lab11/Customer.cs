using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    internal class Customer
    {
        private string surname;
        private string name;
        private int cardNumber;
        private double balance;

        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public int CardNumber { get => cardNumber; set => cardNumber = value; }
        public double Balance { get => balance; set => balance = value; }

        public static int Count = 0;
        public static string about = "Этот класс содержит информацию о заказчиках.";
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

        public void PrintName(Customer customer)
        {
            Console.WriteLine($"{customer.Surname} {customer.Name}");
        }

        public static string GetInfoAboutClass()
        {
            return about;
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
