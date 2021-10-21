using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UserNotification.Domain.Commands;
using UserNotification.Shared;

namespace UserNotification.Domain.Entities
{
    public sealed class Users : BaseEntity
    {
        private ICollection<UsersNotifications> _usersNotifications;

        public Users(int Id, string nick, string passWord, string name, string phone, string email) : base(Id)
        {
            Nick = nick;
            PassWord = passWord;
            Name = name;
            Phone = phone;
            Email = email;
            _usersNotifications = new Collection<UsersNotifications>();
        }

        public string Nick { get; private set; }
        public string PassWord { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public IReadOnlyCollection<UsersNotifications> UsersNotifications { get { return _usersNotifications.ToArray(); } }

        public void AddNotifications(ICollection<UpdateUsersNotificationCommand> notifications)
        {
            foreach (var existingChild in _usersNotifications.ToList())
            {
                if (!notifications.Any(c => c.Id == existingChild.Id))
                    _usersNotifications.Remove(existingChild);
            }

            foreach (UpdateUsersNotificationCommand notification in notifications)
            {
                UsersNotifications userNotification = _usersNotifications.ToList().FirstOrDefault(x => x.Id == notification.Id);
                if (userNotification == null)
                {
                    UsersNotifications newObject = new UsersNotifications(notification.Id, notification.Type, notification.Description, notification.Value, notification.BarCode, notification.PaymentDate, notification.PaidDate, notification.PaidBy, notification.Notify);
                    _usersNotifications.Add(newObject);

                }
                else
                {
                    userNotification = userNotification.Copy<UpdateUsersNotificationCommand, UsersNotifications>(notification, userNotification);
                }
            }
        }

        public void AddNotification(UpdateUsersNotificationCommand notification)
        {
            UsersNotifications newObject = new UsersNotifications(notification.Id, notification.Type, notification.Description, notification.Value, notification.BarCode, notification.PaymentDate, notification.PaidDate, notification.PaidBy, notification.Notify);
            _usersNotifications.Add(newObject);
        }

        public void RemoveNotification(UsersNotifications notification)
        {
            _usersNotifications.Remove(notification);
        }

        public void MergeUpdate(Users user, UpdateUserCommand command)
        {
            user = user.Copy<UpdateUserCommand, Users>(command, user);

            foreach (var existingChild in user.UsersNotifications.ToList())
            {
                if (!command.UsersNotifications.Any(c => c.Id == existingChild.Id))
                    user.RemoveNotification(existingChild);
            }

            foreach (UpdateUsersNotificationCommand notification in command.UsersNotifications)
            {
                UsersNotifications userNotification = user.UsersNotifications.ToList().FirstOrDefault(x => x.Id == notification.Id);
                if (userNotification == null)
                {
                    user.AddNotification(notification);
                }
                else
                {
                    userNotification = userNotification.Copy<UpdateUsersNotificationCommand, UsersNotifications>(notification, userNotification);
                }
            }
        }
    }
}
