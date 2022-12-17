using aspnetcore_l20n_i18n.Domain;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Repositories;

namespace aspnetcore_l20n_i18n.Infrastructure.Repositories
{
    public class CorinthiansFanRepository : Repository<CorinthiansFan>, ICorinthiansFanRepository
    {
        public CorinthiansFanRepository(CorinthiansDbContext dbContext) : base(dbContext)
        {
        }
    }
}