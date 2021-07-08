using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpeechBin.Steps
{
    public class CountDownStep : Step
    {
        public int CountDownFrom { get; set; }
        public List<CommentTiming> Comments { get; set; } = new();

        public override Task AcceptAsync(IStepVisitor v) =>
            v.VisitAsync(this);
    }

    public class CommentTiming
    {
        public int TimeMark { get; set; }
        public string Comment { get; set; }
    }
}
