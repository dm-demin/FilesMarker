using FilesMarker.Abstractions;
using FilesMarker.Abstractions.Interfaces;
using FilesMarker.Abstractions.Models.Entities;
using FilesMarker.Repository.Contexts;
using FilesMarker.Repository.Entities;
using FilesMarker.Repository.Implementation;
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
        services.AddScoped<IFileRepository, FilesRepository>();

        return services;
    }
}