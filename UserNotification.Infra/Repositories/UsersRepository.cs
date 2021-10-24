using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UserNotification.Domain.Commands;
using UserNotification.Domain.Entities;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Infra.DBContext;

namespace UserNotification.Infra.Repositories
{
    public sealed class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        private readonly SQLDBContext _sqlDbContext;
        private readonly ICollection<string> childList = new Collection<string>() { "UsersNotifications" };

        public UsersRepository(SQLDBContext sqlDbContext) : base(sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }

        public async Task<Users> DoLogin(LoginCommand loginCommand)
        {
            Users user = await _sqlDbContext.Set<Users>().FirstOrDefaultAsync(x => x.Nick == loginCommand.Nick && x.PassWord == loginCommand.PassWord);
            if (user == null) return user;
            foreach (var child in childList)
            {
                await _sqlDbContext.Entry(user).Collection(child).LoadAsync();
            }
            return user;
        }
    }
}
