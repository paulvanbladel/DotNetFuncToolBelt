using AvoidExceptionsAndNulls;
using DotNetFuncToolBelt;
using System;
using Xunit;

namespace UnitTests
{
    public class ResultClassDemoTests
    {
        [Fact]
        public void CorrectCallToPaymentGatewayGivesPositiveResult()
        {
            Result result = new PaymentGateway().Pay(DateTime.Now, "paulus");
            Assert.Equal(true, result.IsSuccess);
        }

        [Fact]
        public void IncorrectCallToPaymentGatewayGivesNegateResultWithReason()
        {
            Result result = new PaymentGateway().Pay(DateTime.Now, "xpaulus");
            Assert.Equal(false, result.IsSuccess);
            Assert.Equal(ErrorType.NoXinNameAllowed, result.ErrorType);
        }
    }
}
