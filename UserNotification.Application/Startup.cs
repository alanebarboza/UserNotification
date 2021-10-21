using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using UserNotification.Application.Services;
using UserNotification.Domain.Interfaces.Services;
using UserNotification.Infra.DBContext;
using UserNotification.Infra.Dependencies;

namespace UserNotification
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration["ConnectionStrings:SQLServer"];

            services.AddDbContext<SQLDBContext>(opt => opt.UseSqlServer(connectionString));

            services.AddRepositoriesDependency();
            services.AddScoped<IUserServices, UserServices>();

            services.AddMvc().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddControllers();

            services.AddHttpClient();

            services.AddApiVersioning(x =>
            {
                x.ReportApiVersions = true;
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Description Swagger Enum
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "API Notificações de Usuários",
                    Description = $@"Uma API feita ASP.NET Core Web API com objetivo de cadastramento de Lembretes/Notificações do Usuário. 
                                     Aplicado estrutura de DDD e Design Patterns SOLID e Handlers.",
                    Contact = new OpenApiContact
                    {
                        Name = "Alan Evandro Barboza",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/alanebarboza"),
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void EnsureMigrationOfContext<T>(IApplicationBuilder app) where T : DbContext
        {
            var context = app.ApplicationServices.GetService<T>();
            context.Database.Migrate();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/1.0/swagger.json", "User Notifications - Versão 1.0"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
