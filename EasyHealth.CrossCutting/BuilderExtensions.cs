using EasyHealth.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyHealth.CrossCutting;

public static class BuilderExtensions
{
    public static void AddDbContextConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Configration.DefaultConnection = configuration
            .GetConnectionString(nameof(Configration.DefaultConnection)) ?? string.Empty;

        services.AddDbContext<EasyHealthDbContext>(options
            => options.UseNpgsql(Configration.DefaultConnection));
    }
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("EasyHealth.Domain");
        services.AddValidatorsFromAssembly(assembly);
    }
}