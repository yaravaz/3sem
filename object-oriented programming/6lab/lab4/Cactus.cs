using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Cactus : Flower
    {
        private bool hasFlowers;
        public bool HasFlowers
        { 
            get
            {
                return hasFlowers;
            }
            set
            {
                if(value == false)
                {
                    throw new UniqueExceptions.HasFlowersException("А зачем нам кактус без цветов?");
                }
                else
                {
                    hasFlowers = value;
                }
            }
        }
        public Cactus(string name, string lifespan, string color, string size, int price, bool hasflowers) : base(name, lifespan, color, size, price)
        {
            HasFlowers = hasflowers;
            Price = price;
        }
        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} -  {Lifespan} - {Color} - {Size} - {HasFlowers}";
        }
    }
}
