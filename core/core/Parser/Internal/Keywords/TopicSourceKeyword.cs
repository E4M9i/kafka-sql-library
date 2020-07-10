using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class TopicSourceKeyword : StreamizKeyword
    {
        public string TopicName { get; }

        public TopicSourceKeyword(string topicName):
            base(topicName, typeof(WhereKeyword))
        {
            TopicName = topicName;
        }
    }
}
