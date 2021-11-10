using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Shared.Handler;
using UserNotification.Shared.Interfaces;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Domain.Entities;
using System.Collections.Generic;
using UserNotification.Shared.Commands;
using System.Collections.ObjectModel;

namespace UserNotification.Domain.Handlers
{
    public class UsersHandler : IHandler<LoginCommand>, IHandler<CreateUserCommand>, IHandler<UpdateUserCommand>, IHandler<IdCommand>
    {
        private IUsersRepository _usersRepository;
        private readonly ICollection<string> childList = new Collection<string>() { "UsersNotifications" };

        public UsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ICommand> Handle(LoginCommand loginCommand)
        {
            Users user = await _usersRepository.DoLogin(loginCommand);
            return new CommandResultObject<Users>((user != null ? 200 : 400), new List<string>() { (user != null ? "Login efetuado com sucesso." : "Usuário ou Senha inválidos.") }, user);
        }

        public async Task<ICommand> Handle(CreateUserCommand createUserCommand)
        {

            Users user = new Users(0, createUserCommand.Nick, createUserCommand.PassWord, createUserCommand.Name, createUserCommand.Phone, createUserCommand.Email);
            user.AddNotifications(createUserCommand.UsersNotifications);

            await _usersRepository.Insert(user);

            return new CommandResult(200, new List<string>() { "Usuário cadastrado com sucesso." });
        }

        public async Task<ICommand> Handle(UpdateUserCommand updateUserCommand)
        {
            if (await _usersRepository.Any(updateUserCommand.Id))
            {
                //Users user = new Users(updateUserCommand.Id, updateUserCommand.Nick, updateUserCommand.PassWord, updateUserCommand.Name, updateUserCommand.Phone, updateUserCommand.Email);

                Users user = await _usersRepository.Select(updateUserCommand.Id, childList);

                user.MergeUpdate(user, updateUserCommand);

                await _usersRepository.Update(user);
                return new CommandResult(200, new List<string>() { "Usuário alterado com sucesso." });
            }
            else
                return new CommandResult(400, new List<string>() { "Usuário não existe." });
        }

        public async Task<ICommand> Handle(IdCommand removeUserCommand)
        {
            if (await _usersRepository.Any(removeUserCommand.Id))
            {
                await _usersRepository.Delete(removeUserCommand.Id);
                return new CommandResult(200, new List<string>() { "Usuário excluído com sucesso." });
            }
            else
                return new CommandResult(400, new List<string>() { "Usuário não existe." });
        }
    }
}
