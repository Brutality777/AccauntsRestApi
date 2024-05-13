using Account.Service.Application;
using Account.Service.Application.CommandHandlers;
using Account.Service.Application.QueryHandlers;
using Account.Service.Domain;
using Account.Service.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Account.Service
{
    public static class AccountServiceInstaller
    {
        public static IServiceCollection AddAccountService(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AccountDbContext>(x =>
            {
                x.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    options.MigrationsHistoryTable($"__{nameof(AccountDbContext)}");
                });
            });
            services.AddScoped<IAccountDbContext, AccountDbContext>();
            services.AddMediatR(x => { x.RegisterServicesFromAssembly(typeof(AddAccountCommandHandler).Assembly); });
            services.AddMediatR(x => { x.RegisterServicesFromAssembly(typeof(GetByIdAccountQueryHandler).Assembly); });
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            return services;
        }
        public static IApplicationBuilder ApplyAccountMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<AccountDbContext>();
            context?.Database.Migrate();
            return app;
        }
    }
}
