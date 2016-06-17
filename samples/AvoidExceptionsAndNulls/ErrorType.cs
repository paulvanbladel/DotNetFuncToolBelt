using DotNetFuncToolBelt;

namespace AvoidExceptionsAndNulls
{
    public class ErrorType : ErrorTypebase
    {
        public static readonly ErrorType DatabaseCanCauseALotOfTrouble
            = new ErrorType(1, "Database error of some sort", "some addition value I might use when dealing with error");
        public static readonly ErrorType NoXinNameAllowed
            = new ErrorType(2, "No X in Name Allowed", "some addition value I might use when dealing with error");

        private ErrorType(int value, string displayName, string myAdditionalValue)
           : base(value, displayName, myAdditionalValue) { }
    }
}
