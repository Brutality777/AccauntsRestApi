using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Routing
{
    public static class AccountRoutingInstaller
    {
        public static IServiceCollection AddAccountRouting(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
