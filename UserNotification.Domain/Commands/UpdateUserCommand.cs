using System.Collections.Generic;
using UserNotification.Domain.Entities;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public sealed class UpdateUserCommand: ICommand
    {
        public UpdateUserCommand(int id, string nick, string passWord, string name, string phone, string email, IReadOnlyCollection<UpdateUsersNotificationCommand> usersNotifications)
        {
            Id = id;
            Nick = nick;
            PassWord = passWord;
            Name = name;
            Phone = phone;
            Email = email;
            UsersNotifications = usersNotifications;
        }

        public int Id { get; set; }
        public string Nick { get; private set; }
        public string PassWord { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<UpdateUsersNotificationCommand> UsersNotifications { get; private set; }
    }
}
