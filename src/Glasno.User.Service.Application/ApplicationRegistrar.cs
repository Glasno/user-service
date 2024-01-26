namespace Glasno.User.Service.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class ApplicationRegistrar
{
    public static IServiceCollection RegisterApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly));
        
        return services;
    }
}
