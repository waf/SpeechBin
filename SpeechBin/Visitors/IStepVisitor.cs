using System.Threading.Tasks;

namespace SpeechBin.Steps
{
    public interface IStepVisitor
    {
        Task VisitAsync(SayStep sayStep);
        Task VisitAsync(CountDownStep countdownStep);
    }
}