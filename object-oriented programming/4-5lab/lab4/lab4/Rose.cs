using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    partial class Rose : Flower
    {
        public bool HasThorns { get; set; }
        public Rose(string name, string lifespan, string color, string size, bool hasThorns, int price) : base(name, lifespan, color, size, price)
        {
            HasThorns = hasThorns;
            Price = price;
        }
    }
}
