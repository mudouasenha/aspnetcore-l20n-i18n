using aspnetcore_l20n_i18n.Domain.Entities;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Data.Contexts;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Repositories;

namespace aspnetcore_l20n_i18n.Infrastructure.Repositories
{
    public class FootballMatchRepository : Repository<FootballMatch>, IFootballMatchRepository
    {
        public FootballMatchRepository(CorinthiansDbContext dbContext) : base(dbContext)
        {
        }
    }
}