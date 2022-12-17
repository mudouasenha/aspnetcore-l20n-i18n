using aspnetcore_l20n_i18n.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aspnetcore_l20n_i18n.Infrastructure.Data.Configs
{
    public class CorinthiansFanConfig : IEntityTypeConfiguration<CorinthiansFan>
    {
        public void Configure(EntityTypeBuilder<CorinthiansFan> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Address).HasColumnType("varchar").HasMaxLength(70);
            builder.Property(p => p.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Country).HasColumnType("varchar").HasMaxLength(35).IsRequired();
            builder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime");
        }
    }
}