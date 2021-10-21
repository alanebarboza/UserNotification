using System.Threading.Tasks;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Shared.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommand> Handle(T command);
    }
}
