using System;
using System.IO;
using System.Threading.Tasks.Dataflow;
namespace cadnvert
{
    public class ValidateFile
    {
        public TransformBlock<Payload, WorkSet> Block { get; } = new TransformBlock<Payload, WorkSet>(payload =>
        {
            if (!File.Exists(payload.SourceFile))
            {
                Console.WriteLine($"Invalid file {payload.SourceFile}");
                return new WorkSet() { FileIsValid = false };
            }
            var templateFullPath =  TemplateMap.GetTemplate(Path.GetFileName(payload.SourceFile));
            if (string.IsNullOrEmpty(templateFullPath))
            {
                Console.WriteLine($"No template found for the file {payload.SourceFile}");
                return new WorkSet() { FileIsValid = false };
            }

            if (!Directory.Exists(payload.DestinationFolder))
            {
                Console.WriteLine($"Invalid destination path: {payload.DestinationFolder}");
                payload.DestinationFolder = Path.GetDirectoryName(payload.SourceFile);
                Console.WriteLine($"Switching to default destination path: {payload.DestinationFolder}");
            }
          

            var destinationFile  = Path.Combine(
                payload.DestinationFolder, 
                $"{(payload.TimeStampDestination? File.GetCreationTime(payload.SourceFile).ToString("yyyy-MM-dd_HH-mm") : string.Empty)}_{Path.GetFileName(payload.SourceFile)}.csv");

            return new WorkSet()
            {
                FileIsValid = true, 
                File = payload.SourceFile, 
                Template = templateFullPath,
                DestinationFile = destinationFile
            };
        });
    }
}
