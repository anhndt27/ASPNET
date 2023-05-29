using Microsoft.EntityFrameworkCore;

namespace ASPNETDAL.Context;

public partial class AppDbContext
{
    private Guid _instanceId = Guid.NewGuid();

    public static void AddBaseOptions(DbContextOptionsBuilder<AppDbContext> builder, string connectionString)
    {
        if (builder == null)
            throw new ArgumentNullException(nameof(builder));

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Connection string must be provided", nameof(connectionString));

        builder.UseSqlServer(connectionString, x => { x.EnableRetryOnFailure(); });
    }
}