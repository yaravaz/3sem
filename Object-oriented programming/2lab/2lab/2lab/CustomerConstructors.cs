using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2lab
{
    public partial class Customer
    {
        static Customer()
        {
            countOfCustomers = 0;
        }
        public Customer(string surname, string name, string patronymic, string adress, string cardNumber, double balance)
        {
            this.idCustomer = Math.Abs(balance.GetHashCode()); ;
            this.surnameCustomer = surname;
            this.nameCustomer = name;
            this.patronymicCustomer = patronymic;
            this.adressOfCustomer = adress; 
            this.cardNumber = cardNumber;
            this.balanceCustomer = balance;
            Customer.countOfCustomers++;
        }
        public Customer()
        {
            idCustomer = -1;
            surnameCustomer = "Undefined";
            nameCustomer = "Undefined";
            patronymicCustomer = "Undefined";
            adressOfCustomer = "Undefined";
            cardNumber = "Undefined";
            balanceCustomer = 0;
            Customer.countOfCustomers++;
        }

        /*
        private Customer(string vipNumber)
        {
            cardNumber = vipNumber;
        }
        */
    }
}
