using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Commands
{
    public class UsersCommand : ICommand
    {
        public UsersCommand(int id, string name, string phone, string email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
    }
}
