namespace DotNetFuncToolBelt
{
    public class ErrorTypebase : Enumeration<int, ErrorTypebase>
    {
        protected ErrorTypebase(int value, string displayName, string myAdditionalValue)
         : base(value, displayName)
        {
            this.MyAdditionalValue = myAdditionalValue;
        }

        public string MyAdditionalValue { get; set; }

    }

}