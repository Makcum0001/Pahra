using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pahra.Domain.Repositories;
using Pahra.Infrastructure.Data;
using Pahra.Infrastructure.Data.Repositories;

namespace Pahra.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IParticipantRepository, ParticipantRepository>();

        return services;
    }
}
