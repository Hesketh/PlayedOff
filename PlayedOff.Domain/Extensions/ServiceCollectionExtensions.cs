using Microsoft.Extensions.DependencyInjection;
using PlayedOff.Domain.Services;

namespace PlayedOff.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayedOffServices(this IServiceCollection serviceCollection) where T : DelegatingHandler
    {
        serviceCollection.AddTransient<IUserService, UserService>();

        return serviceCollection;
    }
}