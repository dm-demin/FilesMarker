using FilesMarker.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilesMarker.Repository.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FilesMetadataContext>(options => 
            options.UseNpgsql(connectionString));
        
        return services;
    }
}