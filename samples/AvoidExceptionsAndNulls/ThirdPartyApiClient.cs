using System;

namespace AvoidExceptionsAndNulls
{
    internal class ThirdPartyApiClient
    {
        public ThirdPartyApiClient()
        {
        }

        internal void DoPayment(DateTime date, string customerName)
        {
            if (customerName.StartsWith("x"))
            {
                throw new NoXinNameException("name starts with x, not allowed");
            }
        }
    }
}