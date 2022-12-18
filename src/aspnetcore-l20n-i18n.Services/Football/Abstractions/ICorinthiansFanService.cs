using aspnetcore_l20n_i18n.Domain;
using aspnetcore_l20n_i18n.Services.Common;
using aspnetcore_l20n_i18n.Services.DTOs;

namespace aspnetcore_l20n_i18n.Services.Football.Abstractions
{
    public interface ICorinthiansFanService
    {
        Task<Result<CorinthiansFan>> Register(UserCreateCommand input);

        Task<EnumerableResult<CorinthiansFan>> GetAll();

        Task<Result<CorinthiansFan>> GetById(int id);
    }
}