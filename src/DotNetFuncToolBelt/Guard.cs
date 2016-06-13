using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DotNetFuncToolBelt
{
    public class Guard
    {
        /// <summary>
        /// Requires the argument to not be null.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNull(object value, string argument)
        {
            if (value == null)
                throw new ArgumentNullException(string.Format("{0} cannot be null.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="string"/> to not be null or empty.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNullOrEmpty(string value, string argument)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.Format("{0} cannot be null or empty.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="string"/> to not be null or whitespace.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNullOrWhitespace(string value, string argument)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(string.Format("{0} cannot be null or whitespace.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="IEnumerable{T}"/> to not be null or empty.
        /// </summary>
        /// <typeparam name="T">Type of the argument</typeparam>
        /// <param name="values">The values of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNullOrEmpty<T>(IEnumerable<T> values, string argument)
        {
            if (values == null || !values.Any())
                throw new ArgumentException(string.Format("{0} cannot be null or empty.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="IDictionary{TKey, TValue}"/> to not be null or empty.
        /// </summary>
        /// <typeparam name="TKey">Type of dictionary keys</typeparam>
        /// <typeparam name="TValue">Type of the dictionary values</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNullOrEmpty<TKey, TValue>(IDictionary<TKey, TValue> dictionary, string argument)
        {
            if (dictionary == null || !dictionary.Any())
                throw new ArgumentException(string.Format("{0} cannot be null or empty.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="int"/> to not be negative.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNegative(int value, string argument)
        {
            if (value < 0)
                throw new ArgumentException(string.Format("{0} cannot be negative.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="int"/> to not be 0 or negative.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotZeroOrNegative(int value, string argument)
        {
            if (value <= 0)
                throw new ArgumentException(string.Format("{0} cannot be 0 or negative.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="decimal"/> to not be negative.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotNegative(decimal value, string argument)
        {
            if (value < 0M)
                throw new ArgumentException(string.Format("{0} cannot be negative.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="decimal"/> to not be 0 or negative.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotZeroOrNegative(decimal value, string argument)
        {
            if (value <= 0M)
                throw new ArgumentException(string.Format("{0} cannot be 0 or negative.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="decimal"/> to not be 0.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsNotZero(decimal value, string argument)
        {
            if (value == 0M)
                throw new ArgumentException(string.Format("{0} cannot be 0.", argument));
        }

        /// <summary>
        /// Requires the argument of type <see cref="string"/> to have a maximum length.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="length">The maximum length.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void HasMaxLength(string value, int length, string argument)
        {
            if (value != null && value.Length > length)
                throw new ArgumentException(string.Format("{0} cannot have a length greater then {1}.", argument, length));
        }

        /// <summary>
        /// Requires the argument of type <see cref="string"/> to have a minimum length.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="length">The minimum length.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void HasMinLength(string value, int length, string argument)
        {
            if (value != null && value.Length < length)
                throw new ArgumentException(string.Format("{0} cannot have a length lesser then {1}.", argument, length));
        }

        /// <summary>
        /// Requires the argument of type <see cref="string"/> to have a fixed length.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="length">The fixed length.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void HasFixedLength(string value, int length, string argument)
        {
            if (value != null && value.Length != length)
                throw new ArgumentException(string.Format("{0} must have a length equal to {1}.", argument, length));
        }

        /// <summary>
        /// Requires the argument of type <see cref="object"/> to be of the given type.
        /// </summary>
        /// <typeparam name="T">The required type.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsOfType<T>(object value, string argument)
        {
            if (value != null && value.GetType() != typeof(T))
                throw new ArgumentException(string.Format("{0} must be of type {1}.", argument, typeof(T)));
        }

        /// <summary>
        /// Requires the argument to be a defined enum.
        /// </summary>
        /// <typeparam name="T">The required enum type.</typeparam>
        /// <param name="enumeration">The value</param>
        /// <param name="argument">Name of the argument.</param>
        [DebuggerHidden]
        public static void IsDefinedEnum<T>(T enumeration, string argument)
            where T : struct, IConvertible
        {
            if (!Enum.IsDefined(typeof(T), enumeration))
                throw new ArgumentException(string.Format("{0} must be of enum type {1}.", argument, typeof(T)));
        }
    }
}
