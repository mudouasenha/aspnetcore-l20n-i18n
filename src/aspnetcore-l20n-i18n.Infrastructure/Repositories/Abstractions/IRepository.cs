using aspnetcore_l20n_i18n.Domain.Entities;

namespace aspnetcore_l20n_i18n.Infrastructure.Repository.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> Exists(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Delete(int id);

        Task<TEntity> Update(TEntity entity);

        IQueryable<TEntity> AsQueryable();

        Task<TEntity> SelectById(int id);
    }
}