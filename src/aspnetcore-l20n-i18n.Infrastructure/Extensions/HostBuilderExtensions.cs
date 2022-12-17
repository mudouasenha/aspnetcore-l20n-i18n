﻿using aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Extensions
{
    public static class HostBuilderExtensions
    {
        public static async Task InitializeAndRunAsync(this IHost host)
        {
            host.RunMigrations<CorinthiansDbContext>();
            await host.RunAsync();
        }

        public static IHost RunMigrations<TContext>(this IHost host) where TContext : DbContext
        {
            try
            {
                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<TContext>();
                dbContext.Database.Migrate();

                return host;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Message={Message}; Method={Method}",
                    ex.Message,
                    nameof(RunMigrations));
                throw;
            }
        }
    }
}