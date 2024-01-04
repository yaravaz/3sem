using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab4
{
    public class Flower : Bush, IComparable<Flower>
    {
        private string color;
        public string Color {
            get
            {
                return color;
            }
            set 
            {
                //Debug.Assert(value == "коричневый");
                //try
                //{
                    if (value == "Коричневый")
                    {
                        throw new UniqueExceptions.CantBeBrown("Он живой?");
                    }
                    else
                    {
                        color = value;
                    }
                //}
                //catch(UniqueExceptions.CantBeBrown e)
                //{
                //    Console.WriteLine(e.Message);
                //}
            }
        }
        public string Size { get; set; }

        private int price;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if(value == 0)
                {
                    throw new UniqueExceptions.CostIsZeroException("У нас нет ничего бесплатного");
                }
                else
                {
                    price = value;
                }
            }
        }
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
