using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserNotification.Infra.DBContext;

namespace UserNotification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                    var context = services.GetService<SQLDBContext>();
                    // Migration start
                    context.Database.Migrate();
            }

            CreateHostBuilder(args).Build().Run();
        }

        private static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
