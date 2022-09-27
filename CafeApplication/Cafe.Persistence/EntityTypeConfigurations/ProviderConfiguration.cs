using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Provider__3214EC077A40BE52");
            builder.HasIndex(e => e.Name, "UQ__Provider__737584F6CEA0C3C7").IsUnique();
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Name).HasMaxLength(20).IsUnicode(false).HasColumnOrder(1);
        }
    }
}
