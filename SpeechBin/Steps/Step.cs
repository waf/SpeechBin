using System.Threading.Tasks;

namespace SpeechBin.Steps
{
    public abstract class Step
    {
		public abstract Task AcceptAsync(IStepVisitor v);
    }
}