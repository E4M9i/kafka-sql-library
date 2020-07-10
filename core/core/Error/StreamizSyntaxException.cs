using System;

namespace Streamiz.Kafka.SQL.Error
{
    public class StreamizSyntaxException : Exception
    {
        public StreamizSyntaxException(string message)
            : base(message)
        {

        }
    }
}
