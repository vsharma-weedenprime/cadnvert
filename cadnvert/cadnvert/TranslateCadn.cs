using System;
using System.Threading.Tasks.Dataflow;

namespace cadnvert
{
    public class TranslateCadn
    {
        public ActionBlock<WorkSet> Block { get; } = new ActionBlock<WorkSet>(workSet =>
        {
            if (!workSet.FileIsValid)
                return;

            var csv = CadnConvertor.ConvertToCsv(workSet.File, workSet.Template, workSet.DestinationFile);
            if (string.IsNullOrEmpty(csv))
            {
                Console.WriteLine("Conversion failed.");
            }
            else
            {
                Console.WriteLine("Conversion successful.");
            }

        });
    }
}
