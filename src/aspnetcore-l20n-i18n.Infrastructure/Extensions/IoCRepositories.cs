using aspnetcore_l20n_i18n.Infrastructure.Repositories;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Extensions
{
    public static class IoCRepositories
    {
        public static IServiceCollection AddRepositoryInfrastructure(this IServiceCollection services, IConfiguration config) =>
            services.BindOptions(config)
                    .AddDbContext<CorinthiansDbContext>(options => options.UseSqlServer(config.GetConnectionString("Corinthians")))
                        .AddAsyncInitializer<DbContextInitializer<CorinthiansDbContext>>()
                    .AddRepositories()
                    .AddDatabaseTransaction()
                    .AddDatabaseDeveloperPageExceptionFilter();

        public static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped<ICorinthiansFanRepository, CorinthiansFanRepository>()
                .AddScoped<IFootballMatchRepository, FootballMatchRepository>();

        public static IServiceCollection AddDatabaseTransaction(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection BindOptions(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IApplicationBuilder UseDatabaseExceptionFilter(this IApplicationBuilder builder) => builder.UseMigrationsEndPoint();
    }
}