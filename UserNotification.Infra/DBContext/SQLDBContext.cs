using Microsoft.EntityFrameworkCore;
using UserNotification.Infra.EntityTypeConfiguration;

namespace UserNotification.Infra.DBContext
{
    public sealed class SQLDBContext : DbContext
    {
        public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            /* Entity, criação das tabelas no banco */
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(UsersEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelbuilder);
        }


    }
}
