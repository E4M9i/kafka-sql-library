using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class WithKeyword : StreamizKeyword
    {
        public WithKeyword()
            :base ("WITH", typeof(SelectKeyword))
        {

        }
    }
}
