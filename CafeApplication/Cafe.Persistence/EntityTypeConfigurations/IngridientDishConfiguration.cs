using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class IngridientDishConfiguration : IEntityTypeConfiguration<IngridientsDish>
    {
        public void Configure(EntityTypeBuilder<IngridientsDish> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Ingridie__3214EC074CCAB7EA");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.DishId).HasColumnOrder(1);
            builder.Property(e => e.IngridientId).HasColumnOrder(2);
            builder.Property(e => e.IngridientWeight).HasColumnOrder(3);
            builder.HasOne(d => d.Dish).WithMany(p => p.IngridientsDishes)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngridientsDishes_To_Dishes");
            builder.HasOne(d => d.Ingridient).WithMany(p => p.IngridientsDishes)
                .HasForeignKey(d => d.IngridientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngridientsDishes_To_Ingridients");
        }
    }
}
