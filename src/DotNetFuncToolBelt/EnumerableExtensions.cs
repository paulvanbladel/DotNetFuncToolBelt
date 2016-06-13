using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFuncToolBelt
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Ensure list is not null.
        /// </summary>
        public static IEnumerable<T> EnsureNotNull<T>(this IEnumerable<T> source)
        {
            return source ?? new List<T>();
        }

        /// <summary>
        /// Checks wether a list is empty.
        /// </summary>
        /// <typeparam name="T">The specified type of the list.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>True when the list is null or empty, false otherwise.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.EnsureNotNull().Any();
        }
    }
}
