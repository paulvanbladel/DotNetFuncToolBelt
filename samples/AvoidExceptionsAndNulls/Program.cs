using DotNetFuncToolBelt;

namespace AvoidExceptionsAndNulls
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumeke = MyEnumClass.MY_FIRST_ENUM.Value;
            System.Console.WriteLine(enumeke);
        }
    }

    public class MyEnumClass : Enumeration<int, MyEnumClass>  //TValue, TEnum
    {
        public static readonly MyEnumClass MY_FIRST_ENUM
            = new MyEnumClass(1, "first displayname", "some addition value");
        public static readonly MyEnumClass MY_SECOND_ENUM
            = new MyEnumClass(2, "second displayname", "some addition value");

        private MyEnumClass(int value, string displayName, string myAdditionalValue)
            : base(value, displayName)
        {
            this.MyAdditionalValue = myAdditionalValue;
        }

        public string MyAdditionalValue { get; set; }

    }
}
