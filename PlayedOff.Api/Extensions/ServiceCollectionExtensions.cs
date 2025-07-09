using PlayedOff.Api.Filters.Exceptions;

namespace PlayedOff.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayedOffExceptionFilters(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<EntityCreateFailedExceptionFilter>();
        serviceCollection.AddScoped<EntityNotFoundExceptionFilter>();
        serviceCollection.AddScoped<UserForbiddenExceptionFilter>();

        return serviceCollection;
    }
}