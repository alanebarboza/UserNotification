using Microsoft.Extensions.DependencyInjection;
using UserNotification.Domain.Interfaces.Repositories;
using UserNotification.Infra.Repositories;

namespace UserNotification.Infra.Dependencies
{
    public static class RepositoriesDependencies
    {
        public static void AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
