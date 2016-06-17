using System;
using System.Runtime.Serialization;

namespace AvoidExceptionsAndNulls
{
    [Serializable]
    internal class NoXinNameException : Exception
    {
        public NoXinNameException()
        {
        }

        public NoXinNameException(string message) : base(message)
        {
        }

        public NoXinNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoXinNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}