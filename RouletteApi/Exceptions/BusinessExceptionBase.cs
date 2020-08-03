using System;
using System.Runtime.Serialization;

namespace RouletteApi.Exceptions
{
    [Serializable]
    internal abstract class BusinessExceptionBase : Exception
    {
        public BusinessExceptionBase()
        {
        }

        public BusinessExceptionBase(string message) : base(message)
        {
        }

        public BusinessExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}