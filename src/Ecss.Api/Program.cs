using Ecss.Api.Conventions;
using Ecss.Api.Extensions;
using Ecss.Api.Middleware;
using Ecss.Business;
using Ecss.DataAccess;
using Ecss.DataAccess.ExternalServices;
using Ecss.Domain.Interfaces.ExternalServices;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors();
    builder.Services
        .AddControllers(options =>
        {
            options.Conventions.Add(new KebabCaseRouteConvention());
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase));
        });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerDocument();
    builder.Services
        .AddBusiness()
        .AddDataAccess(builder.Configuration);
    builder.Services.AddAspApiVersioning();
    builder.Host.UseSerilog((context, services, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.With(new VietnamDateTimeEnricher(services.GetRequiredService<IDateTimeProvider>()));
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerDocument();
        app.ApplyMigrations();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseCors(policy => policy
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:4200"));

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}
app.Run();
