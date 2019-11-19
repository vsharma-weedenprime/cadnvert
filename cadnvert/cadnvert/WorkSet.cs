using NPOI.Util;

namespace cadnvert
{
    public class WorkSet
    {
        public bool FileIsValid { get; set; }
        public string File { get; set; }
        public string Template { get; set; }
        public string DestinationFile { get; set; }
    }
}
