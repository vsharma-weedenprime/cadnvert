using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace cadnvert
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("/************************ USAGE ************************/");
                Console.WriteLine("pass a fully qualified source file uri and an optional ");
                Console.WriteLine("destination folder to cadnvert.  Example:");
                Console.WriteLine(@"cadnvert [uri] <destination>");
                return -1;
            }

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            var validateBlock = new ValidateFile().Block;
            var translateBlock = new TranslateCadn().Block;

            // pipeline composition  
            validateBlock.LinkTo(translateBlock, linkOptions);

            // start processing 
            validateBlock.Post(new Payload()
            {
                SourceFile = args[0], 
                DestinationFolder = args.Length > 1 ? args[1] : "", 
                TimeStampDestination = args.Length <= 2 || bool.Parse(args[2])
            });

            // mark the validation block complete 
            validateBlock.Complete();

            // wait for task completion 
            translateBlock.Completion.Wait();

            return 0;
        }
    }
}
