using System.Collections.Generic;
using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Domain.Entities;

namespace UserNotification.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Users> DoLogin(LoginCommand loginCommand);
        Task Insert(Users obj);
        Task Update(Users obj);
        Task Delete(int id);
        Task<ICollection<Users>> Select();
        Task<Users> Select(int id, IEnumerable<string> childList);
        Task<Users> FirstOrDefault(IEnumerable<string> childList);
        Task<bool> Any(int id);
    }
}
