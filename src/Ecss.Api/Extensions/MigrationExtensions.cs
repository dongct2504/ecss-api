using Ecss.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecss.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        using EcssDbContext dbContext = scope.ServiceProvider.GetRequiredService<EcssDbContext>();
        dbContext.Database.Migrate();
    }
}
