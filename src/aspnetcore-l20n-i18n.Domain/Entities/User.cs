using aspnetcore_l20n_i18n.Domain.Entities;

namespace aspnetcore_l20n_i18n.Domain
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}