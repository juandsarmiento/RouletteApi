using System;
using System.Runtime.Serialization;

namespace RouletteApi.Exceptions
{
    [Serializable]
    internal class MongoDocumentNotFound : BusinessExceptionBase
    {
        public MongoDocumentNotFound()
        {
        }

        public MongoDocumentNotFound(string message) : base(message)
        {
        }

        public MongoDocumentNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MongoDocumentNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}