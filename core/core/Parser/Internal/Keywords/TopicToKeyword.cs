using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class TopicToKeyword : StreamizKeyword
    {
        public string TopicName { get; }

        public TopicToKeyword(string topicName)
            : base(topicName, typeof(WithKeyword))
        {
            TopicName = topicName;
        }
    }
}
