using System;
using System.Collections.Generic;
using System.Text;

namespace cadnvert
{
    public class Payload
    {
        public string SourceFile { get; set; }
        public string DestinationFolder { get; set; }
        public bool TimeStampDestination { get; set; } = true;
    }
}
