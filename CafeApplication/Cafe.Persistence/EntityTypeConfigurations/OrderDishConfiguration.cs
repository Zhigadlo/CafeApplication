using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__OrderDis__3214EC07366CFAC4");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.OrderId).HasColumnOrder(1);
            builder.Property(e => e.DishId).HasColumnOrder(2);
            builder.Property(e => e.DishCount).HasColumnOrder(3);
            builder.HasOne(d => d.Dish).WithMany(p => p.OrderDishes)
                .HasForeignKey(d => d.DishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDishes_To_Dishes");
            builder.HasOne(d => d.Order).WithMany(p => p.OrderDishes)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDishes_To_Orders");
        }
    }
}
