using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Pahra.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var mediatrLicense = configuration["Mediatr:LicenseKey"];

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            if (!string.IsNullOrEmpty(mediatrLicense))
            {
                cfg.LicenseKey = mediatrLicense;
            }
        });

        return services;
    }
}
