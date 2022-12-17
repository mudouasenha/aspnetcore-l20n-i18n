using Extensions.Hosting.AsyncInitialization;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Extensions
{
    public class DbContextInitializer<TContext> : IAsyncInitializer where TContext : DbContext
    {
        private readonly TContext dbContext;

        public DbContextInitializer(TContext dbContext) => this.dbContext = dbContext;

        public async Task InitializeAsync() => await dbContext.Database.MigrateAsync();
    }
}