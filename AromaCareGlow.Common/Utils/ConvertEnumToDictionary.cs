using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AromaCareGlow.Common.Utils
{
    public static class ConvertEnumToDictionary
    {
        /// <summary>
        /// Getting a Dictionary from an Enum
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumPairs(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (!type.IsEnum)
                throw new ArgumentException("Only enumeration type is expected.");

            Dictionary<int, string> pairs = new Dictionary<int, string>();

            foreach (int i in Enum.GetValues(type))
            {
                pairs.Add(i, Enum.GetName(type, i));
            }

            return pairs;
        }


    }
}
















