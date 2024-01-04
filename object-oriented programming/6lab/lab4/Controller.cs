using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public static class Controller
    {
        public static void SortByName(Bouquet bouquet)
        {
            bouquet.Flowers.Sort();
        }
        public static void FindByColor(Bouquet bouquet, string color)
        {
            foreach(var s in bouquet.Flowers)
            {
                if(s.Color == color)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public static void FindPriceOfBouquet(Bouquet bouquet)
        {
            int sum = 0;
            foreach(var s in bouquet.Flowers)
            {
                sum += s.Price;
            }
            Console.WriteLine(sum);
        }
    }
}
