using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FileMarker.Abstractions;
using FilesMarker.Repository.Implementation;
using FilesMarker.Repository.Extensions;
using FilesMarker.Repository.Models;
using Xunit;

namespace FilesMarker.Tests.Integration;

public class FilesRepositoryTests
{
    private readonly IRepository<FileMetadata> _filesRepository;

    public FilesRepositoryTests()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var configuration = configurationBuilder.AddJsonFile("appsettings.test.json").Build();
        
        var serviceCollection = new ServiceCollection();
        var dbConnectionString = configuration.GetSection("ConnectionString").Value ?? string.Empty;
        serviceCollection.AddRepository(dbConnectionString);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        _filesRepository = serviceProvider.GetService<IRepository<FileMetadata>>();
    }

    [Fact]
    public async Task AddNewFileSuccess()
    {
        
        var fileName = "/testpath/testfile.txt";

        FileMetadata metadata = new FileMetadata()
        {
            FilePath = fileName,
        };

        await _filesRepository.AddAsync(metadata);
    }
    
    [Fact]
    public void GetFileSuccess()
    {
    }
    
    [Fact]
    public void GetFileFailedNotFound()
    {
    }
}