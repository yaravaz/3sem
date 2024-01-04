using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2lab
{
    partial class Customer
    {
        public int _idCustomer { get => idCustomer; }
        public string _surnameCustomer 
        {
            get
            {
                return surnameCustomer;
            }
            set
            {
                Regex regex = new Regex(@"\w");
                if(regex.IsMatch(value))
                {
                    surnameCustomer = value;
                }
                else
                {
                    Console.WriteLine("Некорректно введена фамилия");
                }
            }
        }

        public string _nameCustomer
        {
            get
            {
                return nameCustomer;
            }
            set
            {
                Regex regex = new Regex(@"\w");
                if (regex.IsMatch(value))
                {
                    nameCustomer = value;
                }
                else
                {
                    Console.WriteLine("Некорректно введено имя");
                }
            }
        }

        public string _patronymicCustomer
        {
            get
            {
                return patronymicCustomer;
            }
            set
            {
                Regex regex = new Regex(@"\w");
                if (regex.IsMatch(value))
                {
                    patronymicCustomer = value;
                }
                else
                {
                    Console.WriteLine("Некорректно введено отчество");
                }
            }
        }

        public string _adressOfCustomer
        {
            get
            {
                return adressOfCustomer;
            }
            private set
            {
                adressOfCustomer = value;
            }
        }

        public string _cardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                Regex regex = new Regex("[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}");
                if (regex.IsMatch(value))
                {
                    cardNumber = value;
                }
                else
                {
                    Console.WriteLine("Некорректно введен номер карты");
                }
            }
        }

        public double _balanceCustomer
        {
            get
            {
                return balanceCustomer;
            }
            set
            {
                balanceCustomer = value;
            }
        }
    }
}
