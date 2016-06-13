using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetFuncToolBelt
{
    /// <summary>
    /// Abstract base class for an Enumeration.
    /// 
    /// Because standard C# enum's have a limitation of only holding a single value,
    /// this base class enables an easy way to instantiate enums based on a full class.
    /// 
    /// The enumeration is made by providing a displayname and unique value to indicate its internal value,
    /// but it doesn't prevent you from adding more properties to the class you'd like to be an enumeration.
    /// 
    /// <![CDATA[
    /// 
    /// Implement example:
    /// 
    /// public class MyEnumClass : Enumeration
    /// {
    ///     public static readonly MyEnumClass MY_FIRST_ENUM = new MyEnumClass("first displayname", 1, "some addition value");
    ///     public static readonly MyEnumClass MY_SECOND_ENUM = new MyEnumClass("second displayname", 2, "some addition value");
    ///     
    ///     private MyEnumClass(string displayName, string value, string myAdditionalValue)
    ///         :base(displayName, value)
    ///     {
    ///         this.MyAdditionalValue = myAdditionValue;
    ///     }
    ///     
    ///     public string MyAdditionalValue { get; set; }
    ///
    /// }
    /// 
    /// 
    /// Usage example:
    /// 
    ///     var theValue = MyEnumClass.MY_FIRST_ENUM;
    /// 
    /// IMPORTANT: 
    ///     - Make the constructor private. Only the enumeration itself should be able to make itself.
    ///     - Mark your "enumerations" as static readonly so they're only instantiated once and cannot be modified.
    /// 
    /// 
    /// The enumeration base class provides you with an IComparable, == and != implementations out of the box.
    /// 
    /// To get a list of all the enumerations of a given class:
    /// 
    ///     var allValues = MyEnumClass.GetAll();
    /// 
    /// To get an enumeration based on its value:
    /// 
    ///     var enumByValue = MyEnumClass.FromValue(1); 
    ///     
    /// ]]>
    /// </summary>
    /// <typeparam name="TValue">Type of the value.</typeparam>
    /// <typeparam name="TEnum">Type of the enumeration.</typeparam>
    public abstract class Enumeration<TValue, TEnum> : IComparable
        where TEnum : Enumeration<TValue, TEnum>
        where TValue : IComparable
    {
        private readonly string displayName;
        private readonly TValue value;

        /// <summary>
        /// Constructs a new instance of an Enumeration.
        /// </summary>
        /// <param name="value">The specified value.</param>
        /// <param name="displayName">The specified displayname.</param>
        protected Enumeration(TValue value, string displayName)
        {
            Guard.IsNotNullOrWhitespace(displayName, "displayName");
            Guard.IsNotNull(value, "value");

            this.displayName = displayName;
            this.value = value;
        }

        /// <summary>
        /// Gets the value for this enumeration.
        /// </summary>
        public TValue Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Gets the displayname for this enumeration.
        /// </summary>
        public string DisplayName
        {
            get { return this.displayName; }
        }

        #region Object's override

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration<TValue, TEnum>;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}", DisplayName);
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration<TValue, TEnum>)other).Value);
        }

        #endregion

        #region Operators

        /// <summary>
        /// The equals '==' operator for two given enumerations.
        /// </summary>
        /// <param name="x">The left side of the equality.</param>
        /// <param name="y">The right side of the equality.</param>
        /// <returns>True when both enumerations are equal, false otherwise.</returns>
        public static bool operator ==(Enumeration<TValue, TEnum> x, Enumeration<TValue, TEnum> y)
        {
            if (Nullable.Equals(x, null) && Nullable.Equals(y, null))
                return true;
            else if (Nullable.Equals(x, null))
                return false;
            else
                return x.Equals(y);
        }

        /// <summary>
        /// The not-equals '!=' operator for two given enumerations.
        /// </summary>
        /// <param name="x">The left side of the equality.</param>
        /// <param name="y">The right side of the equality.</param>
        /// <returns>True when both enumerations are not equal, false otherwise.</returns>
        public static bool operator !=(Enumeration<TValue, TEnum> x, Enumeration<TValue, TEnum> y)
        {
            return !(x == y);
        }

        #endregion

        /// <summary>
        /// Returns a IEnumerable of all the enumerations declared in this enumeration.
        /// </summary>
        /// <returns>IEnumerable of this enumeration.</returns>
        public static IEnumerable<TEnum> GetAll()
        {
            var type = typeof(TEnum);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var enumValue = info.GetValue(null) as TEnum;

                if (enumValue != null)
                {
                    yield return enumValue;
                }
            }
        }

        /// <summary>
        /// Finds the enumeration corresponding with the specified value.
        /// </summary>
        /// <param name="value">The specified value to look-up.</param>
        /// <returns>The enumeration for the specified value.</returns>
        public static TEnum FromValue(TValue value)
        {
            var matchingEnum = GetAll().FirstOrDefault(x => x.Value.CompareTo(value) == 0);

            if (matchingEnum == null)
            {
                throw new ApplicationException(
                    string.Format("{0} is not a valid value for {1}", value, typeof(TEnum)));
            }

            return matchingEnum;
        }

        /// <summary>
        /// Finds the enumeration corresponding with the specified displayname.
        /// </summary>
        /// <param name="displayName">The specified displayname to look-up.</param>
        /// <returns>The enumeration for the specified displayname.</returns>
        public static TEnum FromDisplayName(string displayName)
        {
            var matchingEnum = GetAll()
                .FirstOrDefault(x => x.DisplayName == displayName);

            if (matchingEnum == null)
            {
                throw new ApplicationException(
                    string.Format("{0} is not a valid displayname for {1}", displayName, typeof(TEnum)));
            }

            return matchingEnum;
        }

    }
}
