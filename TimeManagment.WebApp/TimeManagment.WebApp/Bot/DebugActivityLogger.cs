using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;

namespace TimeManagment.WebApp.Bot
{
    public class DebugActivityLogger : IActivityLogger
    {
        public Task LogAsync(IActivity activity)
        {
            Debug.WriteLine($"From: {activity.From.Id} - To: {activity.Recipient.Id} - Message: {activity.AsMessageActivity()?.Text}");
            return Task.CompletedTask;
        }
    }
}