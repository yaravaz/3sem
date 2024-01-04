using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab13
{
    [Serializable]
    public class Bush : Plant
    {
        public string Lifespan { get; set; }


        [NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public string toIgnore = "esdfgh";


        public Bush(string name, string lifespan, string type = "куст") : base(name, type)
        {
            Lifespan = lifespan;
        }

        public Bush()
        {
            Name = "undefined";
            Type = "Undefined";
            Lifespan = "undefined";
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
