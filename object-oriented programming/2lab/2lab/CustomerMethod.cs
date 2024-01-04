using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab
{
	public partial class Customer
	{
		public static void InputInformation()
		{
			Console.WriteLine("В этом класса хранятся:\n" +
				"ФИО заказчика \n" +
				"Идентификационный номер заказчика\n" +
				"Адрес заказчика\n" +
				"Номер карты заказчика\n" +
				"Баланс");
			Console.WriteLine("Количество заказчиков: ");
			Console.WriteLine($"Всего: {Customer.countOfCustomers}");
		}

        public override bool Equals(object obj)
        {
			if (obj.GetType() != this.GetType() || obj == null) return false;
			{
				Customer dude = (Customer)obj;
				return (nameCustomer == dude.nameCustomer) && 
					(surnameCustomer == dude.surnameCustomer) && 
					(patronymicCustomer == dude.patronymicCustomer);
			}
        }

		public override int GetHashCode()
		{
			return (int)balanceCustomer % countOfCustomers * 42;
		}

		public override string ToString()
        {
			return $"name — {nameCustomer}, " +
				$"surname — {surnameCustomer}, " +
				$"patronymic — {patronymicCustomer}, " +
				$"id — {idCustomer}, " +
				$"adress — {adressOfCustomer}";

		}

		public void DebitingMoney(ref double balance)
		{
			_balanceCustomer -= balance;
			Console.WriteLine("Списание суммы произошло успешно");
		}
        public void CreditingMoney(out double balance)
        {
			balance = 100;
            _balanceCustomer = _balanceCustomer + balance;
			Console.WriteLine("Зачисление на счёт произошло успешно");
        }

    }
}
