using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class SelectFieldsKeyword : StreamizKeyword
    {
        public SelectFieldsKeyword(IEnumerable<string> fields)
            : base(string.Join(",", fields), typeof(FromKeyword))
        {

        }
    }
}
