using aspnetcore_l20n_i18n.Domain.Entities;
using aspnetcore_l20n_i18n.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aspnetcore_l20n_i18n.Infrastructure.Data.Configs
{
    public class FootballMatchConfig : IEntityTypeConfiguration<FootballMatch>
    {
        public void Configure(EntityTypeBuilder<FootballMatch> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Away).HasColumnType("bool").IsRequired().HasDefaultValue(false);
            builder.Property(p => p.Stadium).HasColumnType("varchar").HasMaxLength(70).IsRequired();
            builder.Property(p => p.Adversary).HasColumnType("varchar").HasMaxLength(70).IsRequired();
            builder.Property(p => p.GameType).HasColumnType("tinyint").IsRequired().HasDefaultValue(GameTypeEnum.Masculine);
            builder.Property(p => p.Date).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime");
        }
    }
}