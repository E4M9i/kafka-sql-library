using Streamiz.Kafka.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Streamiz.Kafka.SQL.Internal
{
    internal class StreamizInstance : IStreamizApplication
    {
        private List<IStreamizQuery> querys;
        private IStreamConfig config;
        private StreamBuilder builder = new StreamBuilder();
        private KafkaStream stream = null;

        public StreamizInstance(List<IStreamizQuery> querys, IStreamConfig config)
        {
            this.querys = querys;
            this.config = config;
        }

        public IEnumerable<IStreamizQuery> Querys => querys;

        public void Close()
        {
            stream?.Close();
        }

        public void Dispose()
        {
            Close();
        }

        public void Start(CancellationToken token = default)
        {
            foreach (var query in querys)
                query.Analyze(builder);

            var topology = builder.Build();
            stream = new KafkaStream(topology, config);
            stream.Start(token);
        }
    }
}
