using System;
using System.Runtime.Serialization;

namespace RouletteApi.Exceptions
{
    [Serializable]
    internal class RouletteIsNotOpenException : BusinessExceptionBase
    {
        public RouletteIsNotOpenException()
        {
        }

        public RouletteIsNotOpenException(string message) : base(message)
        {
        }

        public RouletteIsNotOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RouletteIsNotOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}