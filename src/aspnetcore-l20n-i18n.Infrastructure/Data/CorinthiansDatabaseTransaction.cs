using aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Data
{
    public interface IDatabaseTransaction
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }

    public class CorinthiansDatabaseTransaction : IDatabaseTransaction
    {
        private readonly CorinthiansDbContext _context;

        public CorinthiansDatabaseTransaction(CorinthiansDbContext context) => _context = context;

        public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();
    }
}