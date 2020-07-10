using Streamiz.Kafka.Net;
using Streamiz.Kafka.SQL.Internal;
using System.Collections.Generic;

namespace Streamiz.Kafka.SQL
{
    public sealed class SQLBuilder
    {
        private readonly List<string> commands = new List<string>();
        private readonly SQLOptions options;

        #region Ctor

        private SQLBuilder(SQLOptions options)
        {
            this.options = options;
        }

        #endregion

        #region Static 

        public static SQLBuilder Create(SQLOptions options = null)
        {
            options = options ?? new SQLOptions();
            return new SQLBuilder(options);
        }

        public static SQLBuilder Create(IStreamConfig config)
        {
            return new SQLBuilder(new SQLOptions(config));
        }

        #endregion

        #region Methods Build

        public IStreamizApplication Build()
        {
            var querys = new List<IStreamizQuery>();

            foreach (var c in commands)
                querys.Add(options.Parser.Parse(c));

            return new StreamizInstance(querys, options.Config);
        }

        #endregion

        #region Methods Add

        public SQLBuilder Add(string commandText)
        {
            commands.Add(commandText);
            return this;
        }

        #endregion
    }
}
