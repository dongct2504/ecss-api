using Ecss.Business.Interfaces;
using Ecss.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ecss.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
