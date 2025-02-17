using FilesMarker.Repository.Contexts;
using FilesMarker.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var configurationBuilder = new ConfigurationBuilder();

configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

IConfiguration configuration = configurationBuilder.Build();

var services = new ServiceCollection();

var dbConnectionString = configuration.GetSection("ConnectionString").Value ?? string.Empty;
services.AddRepository(dbConnectionString);

var serviceProvider = services.BuildServiceProvider(); // <-- допустимо ли здесь и куда лучше вынести?
var dbContext = serviceProvider.GetService<FilesMetadataContext>(); 
dbContext.Database.Migrate();

