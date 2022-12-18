using aspnetcore_l20n_i18n.Domain.Entities;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Services.Common;
using aspnetcore_l20n_i18n.Services.DTOs;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using aspnetcore_l20n_i18n.Services.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace aspnetcore_l20n_i18n.Services.Football
{
    public class FootballMatchService : IFootballMatchService
    {
        private readonly IFootballMatchRepository _footballMatchRepository;
        private readonly ILogger<IFootballMatchService> _logger;
        private IStringLocalizer<Messages> _localizer;

        public FootballMatchService(IFootballMatchRepository footballMatchRepository, ILogger<IFootballMatchService> logger, IStringLocalizer<Messages> localizer)
        {
            _footballMatchRepository = footballMatchRepository;
            _logger = logger;
            _localizer = localizer;
        }

        public Task<Result<IEnumerable<FootballMatch>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result<FootballMatch>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<FootballMatch>> Register(UserCreateCommand input)
        {
            throw new NotImplementedException();
        }
    }
}