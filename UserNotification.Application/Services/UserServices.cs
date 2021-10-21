using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Domain.Entities;
using UserNotification.Domain.Handlers;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Domain.Interfaces.Services;
using UserNotification.Shared.Interfaces;

namespace UserNotification.Application.Services
{
    public sealed class UserServices : IUserServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICollection<string> childList = new Collection<string>() { "UsersNotifications" };

        public UserServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<ICommand> DoLogin(LoginCommand loginCommand)
        {
            UsersHandler usersHandler = new UsersHandler(_usersRepository);
            return await usersHandler.Handle(loginCommand);
        }

        public async Task<ICommand> Insert(CreateUserCommand createUserCommand)
        {
            UsersHandler usersHandler = new UsersHandler(_usersRepository);
            return await usersHandler.Handle(createUserCommand);
        }
        public async Task<ICommand> Update(UpdateUserCommand updateUserCommand)
        {
            UsersHandler usersHandler = new UsersHandler(_usersRepository);
            return await usersHandler.Handle(updateUserCommand);
        }

        public async Task<ICommand> Delete(IdCommand removeUserCommand)
        {
            UsersHandler usersHandler = new UsersHandler(_usersRepository);
            return await usersHandler.Handle(removeUserCommand);
        }

        public async Task<ICollection<Users>> Select()
        {
            return await _usersRepository.Select();
        }

        public async Task<Users> Select(int id)
        {
            return await _usersRepository.Select(id, childList);
        }

        public async Task<bool> Any(int id)
        {
            return await _usersRepository.Any(id);
        }
        public async Task<Users> FirstOrDefault()
        {
            return await _usersRepository.FirstOrDefault(childList);
        }
    }
}
