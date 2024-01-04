using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;
using System.Xml.XPath;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Bush bush1 = new Bush("Шиповник", "Многолетний");
            Bush bush2 = new Bush("Калина", "Многолетний");
            Bush bush3 = new Bush("Гранат", "Многолетний");
            Bush bush4 = new Bush("Фикус", "Многолетний");

            object result = null;

            BinarySerializator.Serialization(bush1);
            BinarySerializator.Deserialization(out result);
            Console.WriteLine(result.ToString());

            result = null;

            SOAPSerializator.Serialization(bush2);
            SOAPSerializator.Deserialization(out result);
            Console.WriteLine(result.ToString());

            result = null;

            XmlSerializator.Serialization(bush3);
            XmlSerializator.Deserialization(out result);
            Console.WriteLine(result.ToString());

            result = null;

            JsonSerializator.Serialization(bush4);
            JsonSerializator.Deserialization(out result);
            Console.WriteLine(result.ToString());

            List<Bush> bushes = new List<Bush>()
            {
                bush1, bush2, bush3, bush4
            };

            List<Bush> resultList = new List<Bush>();

            JsonSerializator.Serialization(bushes);
            JsonSerializator.DeserializateCollection(out resultList);

            foreach(var item in resultList)
            {
                Console.WriteLine(item.ToString());
            }

            //селекторы

            XmlDocument xmlselect = new XmlDocument();
            xmlselect.Load("note.xml");

            XPathNodeIterator plant = xmlselect.CreateNavigator().Select("//Bush");
            while (plant.MoveNext())
            {
                Console.WriteLine(plant.Current.OuterXml);
            }

            XPathNavigator nameToSelect = xmlselect.CreateNavigator().SelectSingleNode("/Bush/Name[text() = 'Гранат']");
            if (nameToSelect != null)
            {
                Console.WriteLine(nameToSelect.Value);
            }

            XElement root = new XElement("Bush",
               new XElement("Plants", new XElement("Plant"), new XElement("Plant"), new XElement("Plant")),
               new XElement("Name", "Гортензия"),
               new XElement("Type", "куст"),
               new XElement("Lifespan", "Многолетний")
           );

            Console.WriteLine(root);

            var plants2 = root.Descendants("Plant");
            foreach (var plant2 in plants2)
            {
                Console.WriteLine(plant2);
            }

            // Выбор значения элемента <Id>
            var type = root.Element("Type")?.Value;
            Console.WriteLine(type);
        }
    }
}
