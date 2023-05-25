using System.Reflection;
using ASPNETDAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ASPNETDAL;

public class TemporaryDbContextFactory : IDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseSqlServer("Server=localhost;Database=aspnet;Trusted_Connection=True;MultipleActiveResultSets=true",
            optionsBuilder =>
                optionsBuilder.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name));
        return new AppDbContext(builder.Options);
    }
}