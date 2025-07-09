using Microsoft.Extensions.DependencyInjection;

namespace PlayedOff.Api.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayedOffApiClients<T>(this IServiceCollection serviceCollection, Uri uri) where T : DelegatingHandler
    {
        serviceCollection.AddHttpClient<IUserProfileClient, UserProfileClient>(x => x.BaseAddress = uri)
            .AddHttpMessageHandler<T>();

        serviceCollection.AddTransient<T>();

        return serviceCollection;
    }
}