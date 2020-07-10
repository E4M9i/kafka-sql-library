﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class ToKeyword : StreamizKeyword
    {
        public ToKeyword()
            : base("TO", typeof(TopicToKeyword))
        {

        }
    }
}
