using Streamiz.Kafka.Net;
using Streamiz.Kafka.Net.SerDes;
using Streamiz.Kafka.SQL.Parser.Internal.Keywords;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamiz.Kafka.SQL.Internal
{
    internal class StreamizQuery : IStreamizQuery
    {
        private readonly IEnumerable<StreamizKeyword> keywords;

        public StreamizQuery(IEnumerable<StreamizKeyword> keywords)
        {
            this.keywords = keywords;
        }

        public void Analyze(StreamBuilder builder)
        {
            if (keywords.Contains(new StreamKeyword()))
            {
                BuildStream(builder, keywords.OfType<StreamKeyword>().FirstOrDefault());
            }
            // TODO : 
        }

        private void BuildStream(StreamBuilder builder, StreamKeyword streamKeyword)
        {
            // FOR MOMENT : 
            var to = streamKeyword.GetKeyword<TopicToKeyword>();
            var source = streamKeyword.GetKeyword<TopicSourceKeyword>();

            builder
                .Stream<StringSerDes, StringSerDes>(source.TopicName)
                .To(to.TopicName);
        }

    }
}
