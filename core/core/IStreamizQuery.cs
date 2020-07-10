using Streamiz.Kafka.Net;
using Streamiz.Kafka.SQL.Parser.Internal.Keywords;
using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL
{
    public interface IStreamizQuery
    {
        void Analyze(StreamBuilder builder);
    }
}
