using aspnetcore_l20n_i18n.Services.Extensions.Policies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcore_l20n_i18n.Services.Extensions;

public static class IoCServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }

    public static IServiceCollection AddExampleHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient("Example").AddPolicyHandler(request => HttpClientPolicies.ExponentialBackOffHttpRetry);

        return services;
    }
}