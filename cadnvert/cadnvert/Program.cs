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
                if (args.Length != 1)
            {
                Console.WriteLine("/************************ USAGE ************************/");
                Console.WriteLine("pass a fully qualified file uri to cadnvert. Example:");
                Console.WriteLine(@"cadnvert [uri]");
                return -1;

            }

            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
            var validateBlock = new ValidateFile().Block;
            var translateBlock = new TranslateCadn().Block;

            // pipeline composition  
            validateBlock.LinkTo(translateBlock, linkOptions);

            // start processing 
            validateBlock.Post(args[0]);

            // mark the validation block complete 
            validateBlock.Complete();

            // wait for task completion 
            translateBlock.Completion.Wait();

            return 0;
        }
    }
}
