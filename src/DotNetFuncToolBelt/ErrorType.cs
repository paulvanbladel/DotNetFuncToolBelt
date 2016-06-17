namespace DotNetFuncToolBelt
{
    public enum ErrorType
    {
        DatabaseIsOffline,
        CustomerAlreadyExists,
        NoXinNameAllowed
        // More stuff here...
    }


    //public class ErrorType : Enumeration<int, ErrorType>  //TValue, TEnum
    //{
    //    public static readonly ErrorType MY_FIRST_ENUM
    //        = new ErrorType(1, "Database error of some sort", "some addition value");
    //    public static readonly ErrorType NoXinNameAllowed
    //        = new ErrorType(2, "No X in Name Allowed", "some addition value");

    //    private ErrorType(int value, string displayName, string myAdditionalValue)
    //        : base(value, displayName)
    //    {
    //        this.MyAdditionalValue = myAdditionalValue;
    //    }

    //    public string MyAdditionalValue { get; set; }

    //}

}