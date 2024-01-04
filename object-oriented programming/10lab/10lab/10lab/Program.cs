using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10lab
{
    internal class Program
    {

        static Random random = new Random();
        static void Main(string[] args)
        {
            // ------------------------------------------------------------

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            int n = 5;

            var monthsLength = from month in months
                               where month.Length > n
                               select month;

            Console.WriteLine("длинна > n");
            foreach (var month in monthsLength)
            {
                Console.WriteLine(month);
            }

            var summerMonths = from month in months
                               where month == months[0] || month == months[5] || month == months[6]
                                   || month == months[7] || month == months[10] || month == months[11]
                               select month;

            Console.WriteLine("зимние и летние");
            foreach (var month in summerMonths)
            {
                Console.WriteLine(month);
            }

            var order = from month in months
                        orderby month
                        select month;

            Console.WriteLine("по алфавиту");
            foreach (var month in order)
            {
                Console.WriteLine(month);
            }

            var letter = from month in months
                         where month.Contains('u')
                         select month;

            Console.WriteLine("с буквой u");
            foreach (var month in letter)
            {
                Console.WriteLine(month);
            }

            var monthsLengthFour = from month in months
                                   where month.Length >= 4
                                   select month;

            Console.WriteLine("длинна >= 4");
            foreach (var month in monthsLengthFour)
            {
                Console.WriteLine(month);
            }

            // --------------------------------------

            List<Customer> customers = new List<Customer>();
            
            // создание элементов
            for(char i = 'К'; i != 'А' - 1; i--)
            {

                var customer = new Customer()
                {
                    Surname = i + "Покупатель",
                    Name = "Андрей",
                    Balance = (double)random.Next(0, 99999) / (double)100,
                    CardNumber = random.Next(1000, 9999),
                };
                customers.Add(customer);
            }

            var orderOfCustomer = from customer in customers
                                  orderby customer.Surname
                                  select customer;

            Console.WriteLine("по алфавиту");
            foreach (var customer in orderOfCustomer)
            {
                Console.WriteLine(customer);
            }

            var currentNumber = from customer in customers
                                where customer.CardNumber > 2000 && customer.CardNumber < 6000
                                select customer;

            Console.WriteLine("номер карты 2000-6000");
            foreach (var customer in currentNumber)
            {
                Console.WriteLine(customer);
            }

            int max = customers.Max(a => (int)a.Balance * 100);
            var maxCustomer = from customer in customers
                              where (int)customer.Balance * 100 == max
                              select customer;

            Console.WriteLine("максимальный покупатель");
            foreach (var customer in maxCustomer)
            {
                Console.WriteLine(customer);
            }

            var sortCollection = customers.Where(item => item.Balance <= max).OrderBy(item => item.Balance);
            var unsortedCollection = sortCollection.Reverse();
            var sortedCollection = unsortedCollection.Take(5);

            Console.WriteLine("5 первых покупателей с максимальной суммой на карте");
            foreach (var item in sortedCollection)
            {
                Console.WriteLine(item);
            }


            // запрос с 5 операторами
            List<Product> products = new List<Product>
            {
            new Product { Name = "TV", Category = "Electronics", Brand = "Sony", Price = 1200 },
            new Product { Name = "Laptop", Category = "Electronics", Brand = "Dell", Price = 1500 },
            new Product { Name = "Laptop2", Category = "Electronics", Brand = "Dell", Price = 1700 },
            new Product { Name = "Headphones", Category = "Electronics", Brand = "Sony", Price = 150 },
            new Product { Name = "Washing Machine", Category = "Appliances", Brand = "LG", Price = 800 },
            new Product { Name = "Refrigerator", Category = "Appliances", Brand = "Samsung", Price = 1200 },
             };

            var nonsense = from product in products
                           where product.Category == "Electronics"
                           orderby product.Price descending
                           group product by product.Brand into brandGroup
                           let totalProducts = brandGroup.Count()
                           where totalProducts > 0
                           select new
                           {
                               Brand = brandGroup.Key,
                               TotalProducts = totalProducts,
                               AveragePrice = brandGroup.Average(p => p.Price),
                               MaxPrice = brandGroup.Max(p => p.Price)
                           };

            foreach (var result in nonsense)
            {
                Console.WriteLine($"Бренд: {result.Brand}, Количество: {result.TotalProducts}, " +
                                  $"Средняя цена: {result.AveragePrice},Максимальная цена: {result.MaxPrice}");
            }


            List<Order> orders = new List<Order>
            {
            new Order { OrderId = 1, CustomerOr = "АПокупатель", TotalAmount = 120.50m },
            new Order { OrderId = 2, CustomerOr = "КПокупатель", TotalAmount = 250.75m },
            new Order { OrderId = 3, CustomerOr = "ДПокупатель", TotalAmount = 75.20m },
            new Order { OrderId = 4, CustomerOr = "Рпокупатель", TotalAmount = 300.00m }
            };

            var ordersAndCustomers = from order1 in orders
                                     join customer in customers on order1.CustomerOr equals customer.Surname
                                     select new
                                     {
                                        OrderId = order1.OrderId,
                                        CustomerName = customer.Surname,
                                        TotalAmount = order1.TotalAmount
                                     };

            foreach (var result in ordersAndCustomers)
            {
                Console.WriteLine($"{result.OrderId} {result.CustomerName} {result.TotalAmount}");
            }
        }
            
    }
}
