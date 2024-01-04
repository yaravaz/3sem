using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class Director
    {
        public int Pay { get; set; }
        public string Position { get; set; }
        public Director(int pay, string position)
        {
            Pay = pay;
            Position = position;
        }


        public void Promote()
        {
            Pay += 300;
            Console.WriteLine("Повышение, зарплата увеличилась на 300 рублей");
        }
         
        public void Fine()
        {
            if (Pay >= 400)
            {
                Pay -= 400;
                Console.WriteLine("Штраф 400 рублей");
            }
            else
            {
                Pay = 0;
                Console.WriteLine("Ужасный сотрудник, уволен");
            }
        }


        public delegate void InfoAboutPromotion();
        public delegate void InfoAboutFine();

        public event InfoAboutPromotion NotifyPromotion;
        public event InfoAboutFine NotifyFine;

        public void DoPromote() => NotifyPromotion?.Invoke();
        public void DoFine() => NotifyFine?.Invoke();


        public override string ToString()
        {
            return $"Текущая зарплата {Position} составляет {Pay} рублей";
        }
    }
}
