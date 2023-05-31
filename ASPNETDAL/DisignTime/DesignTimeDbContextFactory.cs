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
        Console.WriteLine($"DesignTimeDbContextFactory: using base path = {path}");
        DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();
        return new AppDbContext(dbContextOptionsBuilder.Options);
    }
}