namespace aspnetcore_l20n_i18n.Services.DTOs
{
    public class UserCreateCommand
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}