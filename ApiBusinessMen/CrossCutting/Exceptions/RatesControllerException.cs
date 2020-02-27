using System;
using System.Runtime.Serialization;

namespace ApiBusinessMen.CrossCutting.Exceptions
{
    [Serializable]
    public class RatesControllerException : Exception
    {
        public RatesControllerException()
        {
        }

        public RatesControllerException(string message) : base(message)
        {
        }

        public RatesControllerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RatesControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}