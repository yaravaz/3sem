using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab13
{
    [Serializable]
    public abstract class Plant
    {
        public abstract void Delete();
        public string Name { get; set; }
        public string Type { get; set; }

        public Plant(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Plant()
        {
            Name = "undefined";
            Type = "undefined";
        }

        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type}";
        }
    }
}
