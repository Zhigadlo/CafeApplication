using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class IngridientConfiguration : IEntityTypeConfiguration<Ingridient>
    {
        public void Configure(EntityTypeBuilder<Ingridient> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Ingridie__3214EC07981C0780");
            builder.HasIndex(e => e.Name, "UQ__Ingridie__737584F6600C1C0F").IsUnique();
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Name).HasMaxLength(20).IsUnicode(false).HasColumnOrder(1);
        }
    }
}
