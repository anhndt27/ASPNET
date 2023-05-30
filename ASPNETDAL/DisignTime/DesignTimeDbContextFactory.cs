using ASPNETDAL.StaticGlobal;
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

        GetConnectionString.ConnectionString = config.GetConnectionString("DbContextConnection");

        Console.WriteLine($"DesignTimeDbContextFactory: using base path = {path}");
        Console.WriteLine($"DesignTimeDbContextFactory: using connection string = { GetConnectionString.ConnectionString}");

        if (string.IsNullOrWhiteSpace( GetConnectionString.ConnectionString))
        {
            throw new InvalidOperationException("Could not find connection string named 'DbContextConnection'");
        }

        DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();

        AppDbContext.AddBaseOptions(dbContextOptionsBuilder,  GetConnectionString.ConnectionString);

        return new AppDbContext(dbContextOptionsBuilder.Options);
    }
}