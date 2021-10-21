using System.Collections.Generic;
using UserNotification.Domain.Entities;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public sealed class CreateUserCommand : ICommand
    {
        public CreateUserCommand(string nick, string passWord, string name, string phone, string email, ICollection<UpdateUsersNotificationCommand> usersNotifications)
        {
            Nick = nick;
            PassWord = passWord;
            Name = name;
            Phone = phone;
            Email = email;
            UsersNotifications = usersNotifications;
        }

        public string Nick { get; private set; }
        public string PassWord { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public ICollection<UpdateUsersNotificationCommand> UsersNotifications { get; private set; }

    }
}
