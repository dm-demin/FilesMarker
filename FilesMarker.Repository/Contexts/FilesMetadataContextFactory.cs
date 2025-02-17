using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FilesMarker.Repository.Contexts;

public class FilesMetadataContextFactory : IDesignTimeDbContextFactory<FilesMetadataContext>
{
    public FilesMetadataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FilesMetadataContext>();
        
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        optionsBuilder.UseNpgsql(connectionString);

        return new FilesMetadataContext(optionsBuilder.Options);
    }
}
