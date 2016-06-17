using DotNetFuncToolBelt;
using System;

namespace AvoidExceptionsAndNulls
{

    public class PaymentGateway
    {
        public Result Pay(DateTime date, string customerName)
        {
            try
            {
                var client = new ThirdPartyApiClient();
                client.DoPayment(date, customerName);

                return Result.Ok();
            }
            catch (NoXinNameException)
            {
                return Result.Fail(ErrorType.NoXinNameAllowed);
            }
            //don't handle further unknown execption, let it go :)
        }
    }
}
