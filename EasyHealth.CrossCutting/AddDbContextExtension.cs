using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyHealth.CrossCutting;

public static class AddDbContextExtension
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
}