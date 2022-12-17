using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts
{
    public class CorinthiansDbContext : DbContext
    {
        public CorinthiansDbContext(DbContextOptions<CorinthiansDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}