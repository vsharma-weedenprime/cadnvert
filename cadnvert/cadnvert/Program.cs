using System;

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
                new ValidateFile().Block.LinkTo(new TransformBlock().Clo<WorkSet,TOutput>(), )

                return -1; 
            }

            return 0;
        }
    }
}
