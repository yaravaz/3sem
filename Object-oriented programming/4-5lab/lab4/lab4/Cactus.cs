using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Cactus : Flower
    {
        public bool HasFlowers { get; set; }
        public Cactus(string name, string lifespan, string color, string size, int price) : base(name, lifespan, color, size, price)
        {
            HasFlowers = true;
            Price = price;
        }
        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} -  {Lifespan} - {Color} - {Size} - {HasFlowers}";
        }
    }
}
