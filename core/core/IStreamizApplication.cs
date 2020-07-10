using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Streamiz.Kafka.SQL
{
    public interface IStreamizApplication : IDisposable
    {
        IEnumerable<IStreamizQuery> Querys { get; }
        void Start(CancellationToken token = default);
        void Close();
    }
}
