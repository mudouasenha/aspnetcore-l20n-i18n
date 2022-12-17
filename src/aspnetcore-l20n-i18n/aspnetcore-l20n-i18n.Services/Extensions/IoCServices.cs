using aspnetcore_l20n_i18n.Services.Extensions.Policies;
using aspnetcore_l20n_i18n.Services.Football;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcore_l20n_i18n.Services.Extensions;

public static class IoCServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        return services.AddScoped<IFootballMatchService, FootballMatchService>()
            .AddScoped<ICorinthiansFanService, CorinthiansFanService>();
    }

    public static IServiceCollection AddExampleHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("Example").AddPolicyHandler(request => HttpClientPolicies.ExponentialBackOffHttpRetry);

        return services;
    }
}