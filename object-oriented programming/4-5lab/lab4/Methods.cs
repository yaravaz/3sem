using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    partial class Rose : Flower
    {
        public override string ToString()
        {
            return $"{this.GetType()} - {Name} - {Type} -  {Lifespan} - {Color} - {Size} - {HasThorns}";
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() % 42;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Rose m = obj as Rose;
                if (m as Rose == null)
                    return false;
                return m.Name == this.Name;
            }
            else
            {
                return false;
            }
        }
    }
}
