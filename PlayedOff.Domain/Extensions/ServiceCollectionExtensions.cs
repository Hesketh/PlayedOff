using Microsoft.Extensions.DependencyInjection;
using PlayedOff.Domain.Services;

namespace PlayedOff.Domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayedOffServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpContextAccessor();

        serviceCollection.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
        serviceCollection.AddTransient<IUserProfileService, UserProfileService>();

        return serviceCollection;
    }
}