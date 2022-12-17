using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using aspnetcore_l20n_i18n.Services.Resources;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace aspnetcore_l20n_i18n.Services.Football
{
    public class CorinthiansFanService : ICorinthiansFanService
    {
        private readonly ICorinthiansFanRepository _corinthiansFanRepository;
        private readonly ILogger<ICorinthiansFanService> _logger;
        private IStringLocalizer<Messages> _localizer;

        public CorinthiansFanService(ICorinthiansFanRepository corinthiansFanRepository, ILogger<ICorinthiansFanService> logger, IStringLocalizer<Messages> localizer)
        {
            _corinthiansFanRepository = corinthiansFanRepository;
            _logger = logger;
            _localizer = localizer;
        }
    }
}