using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toolbelt.Blazor.SpeechSynthesis;

namespace SpeechBin.Steps
{
    public class SpeechVisitor : IStepVisitor
    {
        private readonly SpeechSynthesis textToSpeech;

        public SpeechVisitor(SpeechSynthesis textToSpeech)
        {
            this.textToSpeech = textToSpeech;
        }

        public async Task SpeakAsync(IReadOnlyCollection<Step> steps)
        {
            foreach (var step in steps)
            {
                await step.AcceptAsync(this);
            }
        }

        public Task VisitAsync(SayStep sayStep)
        {
            textToSpeech.Speak(sayStep.Text);
            return Task.CompletedTask;
        }

        public Task VisitAsync(CountDownStep countdownStep)
        {
            var countdownTask = Task.Delay(TimeSpan.FromSeconds(countdownStep.CountDownFrom));
            var commentTasks = countdownStep.Comments
                .Select(async (c) =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(countdownStep.CountDownFrom - c.TimeMark));
                    textToSpeech.Speak(c.Comment);
                });

            return Task.WhenAll(commentTasks.Prepend(countdownTask));
        }
    }
}
