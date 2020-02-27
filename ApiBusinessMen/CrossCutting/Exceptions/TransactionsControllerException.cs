using System;
using System.Runtime.Serialization;

namespace ApiBusinessMen.CrossCutting.Exceptions
{
    [Serializable]
    public class TransactionsControllerException : Exception
    {
        public TransactionsControllerException()
        {
        }

        public TransactionsControllerException(string message) : base(message)
        {
        }

        public TransactionsControllerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionsControllerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}