using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFuncToolBelt
{
    public static class HashCodeUtils
    {

        /// <summary>
        /// Combines the hash codes of a collection of objects.
        /// </summary>
        /// <param name="objects">The collection of objects to combine.</param>
        /// <returns>A combined hash code for all objects.</returns>
        public static int CombineHashCodes(IEnumerable<object> objects)
        {
            unchecked
            {
                return objects.Aggregate(17, (current, obj) => current * 23 + (obj != null ? obj.GetHashCode() : 0));
            }
        }
    }
}
