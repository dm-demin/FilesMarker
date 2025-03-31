using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FilesMarker.Abstractions.Interfaces;
using FilesMarker.Abstractions.Models.Entities;
using FilesMarker.Repository.Implementation;
using FilesMarker.Repository.Extensions;
using Xunit;

namespace FilesMarker.Tests.Integration;

public class FilesRepositoryTests
{
    private readonly IFileRepository _filesRepository;
    
    public FilesRepositoryTests()
    {
        var configurationBuilder = new ConfigurationBuilder();
        var configuration = configurationBuilder.AddJsonFile("appsettings.test.json").Build();
        
        var serviceCollection = new ServiceCollection();
        var dbConnectionString = configuration.GetSection("ConnectionString").Value ?? string.Empty;
        serviceCollection.AddRepository(dbConnectionString);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        _filesRepository = serviceProvider.GetService<IFileRepository>();
    }

    [Fact]
    public async Task AddNewFileSuccess()
    {
        string fileName = Path.GetRandomFileName();

        var addedFile = await AddNewFileToRepository(fileName);
        
        Assert.NotNull(addedFile);
        Assert.IsType<FileMetadata>(addedFile);
        Assert.IsType<Guid>(addedFile.Id);
        Assert.Equal(addedFile.FilePath, fileName);
    }
    
    [Fact]
    public async Task GetFileSuccess()
    {
        string fileName = Path.GetRandomFileName();
        var addedFile = await AddNewFileToRepository(fileName);

        FileMetadata selectedFile = await _filesRepository.GetByPathAsync(fileName);
        
        Assert.NotNull(selectedFile);
        Assert.Equal(selectedFile.Id, addedFile.Id);
        Assert.Equal(selectedFile.FilePath, addedFile.FilePath);
    }
    
    [Fact]
    public async Task GetFileFailedNotFound()
    {
        string somePath = Path.GetRandomFileName();
        
        await Assert.ThrowsAsync<FileNotFoundException>( async () => await _filesRepository.GetByPathAsync(somePath));
    }

    private async Task<FileMetadata> AddNewFileToRepository(string filePath)
    {
        FileMetadata metadata = new FileMetadata()
        {
            FilePath = filePath,
        };

        return await _filesRepository.AddAsync(metadata);
    }
}