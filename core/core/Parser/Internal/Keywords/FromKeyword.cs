using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class FromKeyword : StreamizKeyword
    {
        public FromKeyword()
            :base ("FROM", typeof(TopicSourceKeyword))
        {

        }
    }
}
