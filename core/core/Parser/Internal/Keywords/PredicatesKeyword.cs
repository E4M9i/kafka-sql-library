using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class PredicatesKeyword : StreamizKeyword
    {
        public PredicatesKeyword(IEnumerable<string> predicates)
            : base(string.Join(",", predicates), true)
        {

        }
    }
}
