using System.Collections.Generic;
using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Domain.Entities;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task<ICommand> Insert(CreateUserCommand obj);
        Task<ICommand> Update(UpdateUserCommand obj);
        Task<ICommand> Delete(IdCommand id);
        Task<ICommand> DoLogin(LoginCommand loginCommand);
        Task<ICollection<Users>> Select();
        Task<Users> Select(int id);
        Task<Users> FirstOrDefault();
        Task<bool> Any(int id);
    }
}
