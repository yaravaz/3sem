using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Bush : Plant, IRemove
    {
        public string Lifespan { get; set; }
        public Bush(string name, string lifespan, string type = "куст") : base(name, type)
        {
            Lifespan = lifespan;
        }
        void IRemove.Delete()
        {
            Console.WriteLine($"Куст {Name} был убран с помощью интерфейса");
        }
        public override void Delete()
        {
            Console.WriteLine($"Куст {Name} убрали");
        }

        virtual public void Care()
        {
            Console.WriteLine($"Куст {Name} был аккуратно подстрижен");
        }

        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} - {Lifespan}";
        }

    }
}
