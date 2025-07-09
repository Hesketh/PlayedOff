using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PlayedOff.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPlayedOffDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<PlayedOffDbContext>(options
            => options.UseInMemoryDatabase("played_off.db"));

        return serviceCollection;
    }
}