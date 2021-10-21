using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Infra.DBContext;

namespace UserNotification.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SQLDBContext _sqlDbContext;

        public BaseRepository(SQLDBContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task Insert(T obj)
        {
            _sqlDbContext.Set<T>().Add(obj);
            await _sqlDbContext.SaveChangesAsync();
        }
        public async Task Update(T obj)
        {
            _sqlDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T obj = await Select(id, new Collection<string>());
            _sqlDbContext.Set<T>().Remove(obj);
            await _sqlDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> Select()
        {
            return await _sqlDbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> Select(int id, IEnumerable<string> childList)
        {
            T obj = await _sqlDbContext.Set<T>().FindAsync(id);
            if (obj == null) return obj;
            foreach (var child in childList)
            {
                await _sqlDbContext.Entry(obj).Collection(child).LoadAsync();
            }
            return obj;
        }

        public async Task<T> FirstOrDefault(IEnumerable<string> childList)
        {
            T obj = await _sqlDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync();
            if (obj == null) return obj;
            foreach (var child in childList)
            {
                await _sqlDbContext.Entry(obj).Collection(child).LoadAsync();
            }
            return obj;
        }

        public async Task<bool> Any(int id)
        {
            return await _sqlDbContext.Set<T>().AsNoTracking().AnyAsync(x => EF.Property<string>(x, "Id") == id.ToString());
        }

    }
}
