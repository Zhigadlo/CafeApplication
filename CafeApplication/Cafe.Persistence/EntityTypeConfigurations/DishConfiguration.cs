using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Dishes__3214EC072FB47970");
            builder.HasIndex(e => e.Name, "UQ__Dishes__737584F6AAF19777").IsUnique();
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.CookingTime).HasColumnOrder(3);
            builder.Property(e => e.Cost).HasColumnOrder(2);
            builder.Property(e => e.Name).HasMaxLength(20).IsUnicode(false).HasColumnOrder(1);
        }
    }
}
