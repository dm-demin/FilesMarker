using FileMarker.Abstractions;
using FilesMarker.Repository.Contexts;
using FilesMarker.Repository.Implementation;
using FilesMarker.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilesMarker.Repository.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<FilesMetadataContext>(options => 
            options.UseNpgsql(connectionString));

        services.AddScoped<DbContext, FilesMetadataContext>();
        services.AddScoped<IRepository<FileMetadata>, FilesRepository>();

        return services;
    }
}