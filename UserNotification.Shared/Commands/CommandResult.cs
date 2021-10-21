using System.Collections.Generic;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Shared.Commands
{
    public sealed class CommandResult : ICommand
    {
        public CommandResult()
        {
            Messages = new List<string>();
        }

        public CommandResult(int statusCode, List<string> messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }

        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
    }
}
