using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class CreateKeyword : StreamizKeyword
    {
        public CreateKeyword()
            : base("CREATE", typeof(StreamKeyword))
        {

        }
    }
}
