using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class IngridientsWarehouseConfiguration : IEntityTypeConfiguration<IngridientsWarehouse>
    {
        public void Configure(EntityTypeBuilder<IngridientsWarehouse> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Ingridie__3214EC07C9325255");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Cost).HasColumnOrder(5);
            builder.Property(e => e.IngridientId).HasColumnOrder(1);
            builder.Property(e => e.ProviderId).HasColumnOrder(6);
            builder.Property(e => e.ReleaseDate).HasColumnOrder(3).HasColumnType("date");
            builder.Property(e => e.StorageLife).HasColumnOrder(4).HasColumnType("date");
            builder.Property(e => e.Weight).HasColumnOrder(2).HasDefaultValueSql("((0))");
            builder.HasOne(d => d.Ingridient).WithMany(p => p.IngridientsWarehouses)
                .HasForeignKey(d => d.IngridientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngridientsWarehouses_To_Ingridients");
            builder.HasOne(d => d.Provider).WithMany(p => p.IngridientsWarehouses)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngridientsWarehouses_To_Providers");
        }
    }
}
