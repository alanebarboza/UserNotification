using System.Collections.Generic;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Shared.Commands
{
    public struct CommandResultObject<T> : ICommand
    {
        public CommandResultObject(int statusCode, List<string> messages, T objectresult)
        {
            Objectresult = objectresult;
            StatusCode = statusCode;
            Messages = messages;
        }

        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public T Objectresult;
    }
}
