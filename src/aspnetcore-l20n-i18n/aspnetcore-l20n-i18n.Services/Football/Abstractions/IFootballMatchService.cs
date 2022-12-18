using aspnetcore_l20n_i18n.Domain.Entities;
using aspnetcore_l20n_i18n.Services.Common;
using aspnetcore_l20n_i18n.Services.DTOs;

namespace aspnetcore_l20n_i18n.Services.Football.Abstractions
{
    public interface IFootballMatchService
    {
        Task<Result<FootballMatch>> Register(UserCreateCommand input);

        Task<Result<IEnumerable<FootballMatch>>> GetAll();

        Task<Result<FootballMatch>> GetById(int id);
    }
}