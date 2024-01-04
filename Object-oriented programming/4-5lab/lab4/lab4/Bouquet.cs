using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Bouquet
    {
        public string BouquetName { get; set; }
        public Paper BouquetPaper { get; set; }
        public List<Flower> Flowers { get; set; } = new List<Flower>();
        public Bouquet(string bouquetName, Paper bouquetPaper, params Flower[] flowers)
        {
            BouquetName = bouquetName;
            BouquetPaper = bouquetPaper;
            foreach (Flower s in flowers)
            {
                Flowers.Add(s);
            }
        }
        public Bouquet()
        {
            BouquetName = "indefined";
            BouquetPaper = null;
        }

        public void AddFlower(Flower f)
        {
            Flowers.Add(f); 
        }

        public void DeleteFlower(Flower f)
        {
            Flowers.Remove(f);
        }

        public void GetInfo()
        {
            Console.WriteLine("Получение информации о букете:");
            Console.WriteLine($"Название букета: {BouquetName}\nЦвет обёртки: {BouquetPaper}");
            foreach(var s in this.Flowers)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public override string ToString()
        {
            return $"{GetType()} - {BouquetName} - {BouquetPaper}: {Flowers[0]}, {Flowers[1]}, {Flowers[2]}";
        }
        public void Delete()
        {
            Console.WriteLine($"Букет {BouquetName} был бесчувственно выброшен");
        }
    }
}
