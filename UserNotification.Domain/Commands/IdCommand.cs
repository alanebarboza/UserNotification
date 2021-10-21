using System.Collections.Generic;
using UserNotification.Domain.Entities;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public sealed class IdCommand : ICommand
    {
        public int Id { get; set; }
    }
}
