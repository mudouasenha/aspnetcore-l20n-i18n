using aspnetcore_l20n_i18n.Domain.Entities;

namespace aspnetcore_l20n_i18n.Domain
{
    public class CorinthiansFan : EntityBase
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public decimal AccountBalance { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}