using Ecss.DataAccess.Data;
using Ecss.DataAccess.ExternalServices;
using Ecss.DataAccess.UnitOfWorks;
using Ecss.Domain.Interfaces.ExternalServices;
using Ecss.Domain.Interfaces.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecss.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<EcssDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection")));

        services.AddStackExchangeRedisCache(options =>
            options.Configuration = configuration.GetConnectionString("DefaultCachingConnection"));

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
