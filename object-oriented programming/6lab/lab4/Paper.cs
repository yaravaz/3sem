using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public sealed class Paper
    {
        public string Color { get; set; }
        public int Thickness { get; set; }
        public Paper(string color, int thickness)
        { 
            Color = color;
            Thickness = thickness;
        }
        public override string ToString()
        {
            return $"{GetType()} - {Color} - {Thickness}";
        }
    }
}
