using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class UniqueExceptions
    {
        public class HasFlowersException : Exception
        {
            public HasFlowersException(string message) : base(message) { }
        }

        public class CostIsZeroException : Exception
        {
            public CostIsZeroException(string message) : base(message) { }
        }

        public class CantBeBrown : Exception
        {
            public CantBeBrown(string message) : base(message) { }
        }
    }
}
