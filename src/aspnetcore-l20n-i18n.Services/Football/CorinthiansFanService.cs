using aspnetcore_l20n_i18n.Domain;
using aspnetcore_l20n_i18n.Infrastructure.Repositories.Abstractions;
using aspnetcore_l20n_i18n.Services.Common;
using aspnetcore_l20n_i18n.Services.DTOs;
using aspnetcore_l20n_i18n.Services.Football.Abstractions;
using aspnetcore_l20n_i18n.Services.Resources;
using Microsoft.EntityFrameworkCore;
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

        public async Task<EnumerableResult<CorinthiansFan>> GetAll()
        {
            var fans = await _corinthiansFanRepository.AsQueryable().ToListAsync();

            return new EnumerableResult<CorinthiansFan>(fans, _localizer["CorinthiansFansSuccessResult"], true);
        }

        public async Task<Result<CorinthiansFan>> GetById(int id)
        {
            var fan = await _corinthiansFanRepository.SelectById(id);

            if (fan == null)
                return Result<CorinthiansFan>.Fail(_localizer["GetCorinthiansFanByIdFailedResult"]);

            return Result<CorinthiansFan>.Successful(fan, _localizer["GetCorinthiansFanByIdSuccessfulResult"]);
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
                    DateOfBirth = input.DateOfBirth,
                    CreatedAt = DateTime.Now,
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
            var countrieslist = new List<string> { "Brasil", "Estados Unidos" };

            if (!countrieslist.Contains(country))
                return false;

            return true;
        }
    }
}