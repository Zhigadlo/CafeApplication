using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Professi__3214EC07A23C8F41");
            builder.HasIndex(e => e.Name, "UQ__Professi__737584F61E3CB58D").IsUnique();
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Name).HasMaxLength(20).IsUnicode(false).HasColumnOrder(1);
        }
    }
}
