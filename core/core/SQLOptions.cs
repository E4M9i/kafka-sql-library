using Streamiz.Kafka.Net;
using Streamiz.Kafka.SQL.Parser;

namespace Streamiz.Kafka.SQL
{
    public class SQLOptions
    {
        public SQLOptions(IStreamConfig config, IParser parser)
        {
            Config = config ?? new StreamConfig();
            Parser = parser ?? new StreamizParser();
        }

        public SQLOptions(IStreamConfig config)
            : this(config, null)
        {
        }

        public SQLOptions()
            : this(null, null)
        {

        }

        public IStreamConfig Config { get; }
        public IParser Parser { get; }
    }
}
