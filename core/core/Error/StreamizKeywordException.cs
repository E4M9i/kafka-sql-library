using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Error
{
    public class StreamizKeywordException : Exception
    {
        public StreamizKeywordException(string message)
            :base(message)
        {

        }
    }
}
