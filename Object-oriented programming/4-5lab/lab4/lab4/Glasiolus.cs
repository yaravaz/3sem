using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Glasiolus : Flower
    {
        public int CountOfFlowers { get; set; }

        public Seasons Season { get; set; }
        public Glasiolus(string name, string lifespan, string color, string size, int countOfFlowers, Seasons season, int price) : base(name, lifespan, color, size, price)
        {
            CountOfFlowers = countOfFlowers;
            Season = season;
            Price = price;
        }
        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} -  {Lifespan} - {Color} - {Size} - {CountOfFlowers} - {(int)Season}";
        }
    }
}
