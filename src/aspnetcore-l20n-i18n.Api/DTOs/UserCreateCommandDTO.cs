using aspnetcore_l20n_i18n.Services.DTOs;

namespace aspnetcore_l20n_i18n.Api.DTOs
{
    public class UserCreateCommandDTO : UserCreateCommand
    {
        public static UserCreateCommand ToInput(UserCreateCommandDTO src) => new()
        {
            Address = src.Address,
            Country = src.Country,
            Name = src.Name,
            DateOfBirth = src.DateOfBirth,
            PhoneNumber = src.PhoneNumber,
            AccountBalance = src.AccountBalance
        };
    }
}