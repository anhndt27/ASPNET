using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AppDbContext = ASPNETDAL.Context.AppDbContext;

namespace ASPNETDAL.DisignTime;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context.AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        string path = Directory.GetCurrentDirectory();

        IConfigurationBuilder builder =
            new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json");

        IConfigurationRoot config = builder.Build();

        string connectionString = config.GetConnectionString("CleanArchitectureIdentity");

        Console.WriteLine($"DesignTimeDbContextFactory: using base path = {path}");
        Console.WriteLine($"DesignTimeDbContextFactory: using connection string = {connectionString}");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Could not find connection string named 'CleanArchitectureIdentity'");
        }

        DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();

        AppDbContext.AddBaseOptions(dbContextOptionsBuilder, connectionString);

        return new AppDbContext(dbContextOptionsBuilder.Options);
    }
}