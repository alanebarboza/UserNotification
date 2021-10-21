using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserNotification.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
        Task<ICollection<T>> Select();
        Task<T> Select(int id, IEnumerable<string> childList);
        Task<T> FirstOrDefault(IEnumerable<string> childList);
        Task<bool> Any(int id);
    }
}
