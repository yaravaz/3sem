using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Flower : Bush, IComparable<Flower>
    {
        public string Color { get; set; }
        public string Size { get; set; }

        public int Price { get; set; }
        public Flower(string name, string lifespan, string color, string size, int price) : base(name, lifespan)
        {
            Color = color;
            Size = size;
            Price = price;
         }

        public int CompareTo(Flower f)
        {
            return this.Name.CompareTo(f.Name);
        }
        public override void Care()
        {
            Console.WriteLine($"Вы полили цветок {Name}");
        }
        public override void Delete()
        {
            Console.WriteLine($"Цветок {Name} выкинули. А жаль: красивый был");
        }

        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} -  {Lifespan} - {Color} - {Size}";
        }
    }
}
