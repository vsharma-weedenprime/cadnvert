using System.Threading.Tasks.Dataflow;

namespace cadnvert
{
    public class TranslateCadn
    {
        public TransformBlock<WorkSet, bool> Block { get; } = new TransformBlock<WorkSet, bool>(workSet =>
        {

            return true;
        });
    }
}
