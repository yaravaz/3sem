using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Xml.XPath;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace lab13
{
    public static class BinarySerializator
    {
        static BinaryFormatter formatter = new BinaryFormatter();
        public static void Serialization(object obj)
        {
            using (FileStream fs = new FileStream("note.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Cериализация bin");
            }
        }

        public static void Deserialization(out object obj)
        {
            using (FileStream fs = new FileStream("note.dat", FileMode.OpenOrCreate))
            {
                obj = formatter.Deserialize(fs) as Bush;
                Console.WriteLine("Десериализация bin");

            }

        }
    }

    public static class SOAPSerializator
    {
        static SoapFormatter formatter = new SoapFormatter();
        public static void Serialization(object obj)
        {
            using (FileStream fs = new FileStream("note.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Cериализация soap");
            }
        }

        public static void Deserialization(out object obj)
        {
            using (FileStream fs = new FileStream("note.soap", FileMode.OpenOrCreate))
            {
                obj = formatter.Deserialize(fs) as Bush;
                Console.WriteLine("Десериализация soap");

            }

        }
    }
    public static class XmlSerializator
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(Bush));
        public static void Serialization(object obj)
        {
            using (FileStream fs = new FileStream("note.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, obj);
                Console.WriteLine("Cериализация soap");
            }
        }

        public static void Deserialization(out object obj)
        {
            using (FileStream fs = new FileStream("note.xml", FileMode.OpenOrCreate))
            {
                obj = serializer.Deserialize(fs) as Bush;
                Console.WriteLine("Десериализация soap");

            }

        }
    }

    public static class JsonSerializator
    {
        public static void Serialization(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText("note.json", json);
            Console.WriteLine("сериализация json");
        }

        public static void Deserialization(out object obj)
        {
            string json = File.ReadAllText("note.json");
            obj = JsonConvert.DeserializeObject<Bush>(json);
            Console.WriteLine("десериализация json");

        }
        public static void DeserializateCollection(out List<Bush> result)
        {
            string json = File.ReadAllText("note.json");
            result = JsonConvert.DeserializeObject<List<Bush>>(json);
            Console.WriteLine("десериализация list json");
        }
    }
}
