using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal static class StatisticOperation
    {
        public static object Sum(Set set)
        {
            object result = false;

            if (set[0] is int)
            {
                result = 0;

                for (int i = 0; i < set.Count; i++)
                {
                    result = (int)result + (int)set[i];
                }
            }

            if (set[0] is string)
            {
                result = "";

                for (int i = 0; i < set.Count; i++)
                {
                    result = (string)result + set[i];
                }
                    
            }

            return result;
        }

        public static int ListCount(Set set)
        {
            return set.Count;
        }

        public static int MaxMinDifferent(Set set)
        {
            if (set[0] is int)
                return Max(set) - Min(set);

            if (set[0] is string)
                return Max(set) - Min(set);

            return 0;
        }

        private static int Max(Set set)
        {
            int max = int.MinValue;

            if (set[0] is int)
            {
                for(int i = 0; i < set.Count; i++)
                {
                    if ((int)set[i] > max)
                    {
                        max = (int)set[i];
                    }
                }
            }

            if (set[0] is string)
            {
                for (int i = 0; i < set.Count; i++)
                {
                    if (set[i].ToString().Length > max)
                    {
                        max = set[i].ToString().Length;
                    }
                }
            }

            return max;
        }

        private static int Min(Set set)
        {
            int min = int.MaxValue;

            if (set[0] is int)
            {
                for (int i = 0; i < set.Count; i++)
                {
                    if ((int)set[i] < min)
                    {
                        min = i;
                    }
                }
            }

            if (set[0] is string)
            {
                for (int i = 0; i < set.Count; i++)
                {
                    if (set[i].ToString().Length < min)
                    {
                        min = set[i].ToString().Length;
                    }
                }
            }

            return min;
        }
        public static string AddPointToTheEnd(this string str)
        {
            str = str + '.';
            return str;
        }
        public static Set DeleteNullElements(this Set set)
        {
            for(int i = 0; i < set.Count; i++)
            {
                if ((string)set[i] == null)
                {
                    set.Listset.Remove(set[i]);
                }
            }
            return set;
        }
    }
}
