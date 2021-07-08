using System.Threading.Tasks;

namespace SpeechBin.Steps
{
    public class SayStep : Step
    {
        public string Text { get; set; }

        public override Task AcceptAsync(IStepVisitor v) =>
            v.VisitAsync(this);
    }
}