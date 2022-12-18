using aspnetcore_l20n_i18n.Domain;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Services.Common;
using aspnetcore_l20n_i18n.Services.DTOs;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using aspnetcore_l20n_i18n.Services.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Globalization;

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

        public async Task<EnumerableResult<CorinthiansFanResult>> GetAll(string requestCountry)
        {
            var fans = await _corinthiansFanRepository.AsQueryable().ToListAsync();

            return new EnumerableResult<CorinthiansFanResult>(fans.Select(p => GlobalizeCorinthiansUser(p, requestCountry)), _localizer["CorinthiansFansSuccessResult"], true);
        }

        public async Task<Result<CorinthiansFanResult>> GetById(int id, string requestCountry)
        {
            var fan = await _corinthiansFanRepository.SelectById(id);

            if (fan == null)
                return Result<CorinthiansFanResult>.Fail(_localizer["GetCorinthiansFanByIdFailedResult"]);

            return Result<CorinthiansFanResult>.Successful(GlobalizeCorinthiansUser(fan, requestCountry), _localizer["GetCorinthiansFanByIdSuccessfulResult"]);
        }

        public async Task<Result<CorinthiansFan>> Register(UserCreateCommand input)
        {
            try
            {
                if (!IsValidCountry(input.Country))
                    return Result<CorinthiansFan>.Fail(_localizer["NotRegisteredCountry"]);

                var fan = new CorinthiansFan()
                {
                    Name = input.Name,
                    Country = input.Country,
                    Address = input.Address,
                    PhoneNumber = input.PhoneNumber,
                    DateOfBirth = input.DateOfBirth.ToUniversalTime(),
                    AccountBalance = input.AccountBalance,
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                    UpdatedAt = null
                };

                var fanResult = await _corinthiansFanRepository.Insert(fan);

                return Result<CorinthiansFan>.Successful(fanResult, _localizer["CreateCorinthiansFanSuccess"]);
            }
            catch
            {
                return Result<CorinthiansFan>.Fail(_localizer["CreateCorinthiansFanFailed"]);
            }
        }

        private bool IsValidCountry(string country)
        {
            var countrieslist = new List<string> { "Brasil", "United States" };

            if (!countrieslist.Contains(country))
                return false;

            return true;
        }

        private CorinthiansFanResult GlobalizeCorinthiansUser(CorinthiansFan fan, string requestCountry)
        {
            if (requestCountry == "Brasil")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
            }

            if (requestCountry == "United States")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            }

            var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);

            var fanResult = new CorinthiansFanResult()
            {
                Name = fan.Name,
                Country = fan.Country,
                Address = fan.Address,
                PhoneNumber = fan.PhoneNumber,
                DateOfBirth = fan.DateOfBirth.ToString(Thread.CurrentThread.CurrentCulture),
                AccountBalance = ri.ISOCurrencySymbol + " " + fan.AccountBalance.ToString(Thread.CurrentThread.CurrentCulture),
                CreatedAt = DateTime.Now.ToString(Thread.CurrentThread.CurrentCulture),
                UpdatedAt = fan.UpdatedAt?.ToString(Thread.CurrentThread.CurrentCulture)
            };

            return fanResult;
        }
    }
}