using aspnetcore_l20n_i18n.Domain.Enums;

namespace aspnetcore_l20n_i18n.Domain.Entities
{
    public class FootballMatch : EntityBase
    {
        public GameTypeEnum GameType { get; set; }

        public string Adversary { get; set; }

        public string Stadium { get; set; }

        public DateTime Date { get; set; }

        public bool Away { get; set; }
    }
}