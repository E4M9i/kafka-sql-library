using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL
{
    public interface IParser
    {
        IStreamizQuery Parse(string commandText);
    }
}
