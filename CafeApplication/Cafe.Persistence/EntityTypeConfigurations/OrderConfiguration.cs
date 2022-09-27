using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Orders__3214EC072FBB5CE4");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.CustomerName).HasMaxLength(30).IsUnicode(false).HasColumnOrder(2);
            builder.Property(e => e.CustomerPhoneNumber).HasMaxLength(20).IsUnicode(false).HasColumnOrder(3);
            builder.Property(e => e.EmployeeId).HasColumnOrder(6);
            builder.Property(e => e.IsCompleted).HasColumnOrder(5);
            builder.Property(e => e.OrderDate).HasColumnOrder(1).HasColumnType("smalldatetime");
            builder.Property(e => e.PaymentMethod).HasColumnOrder(4);
            builder.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_To_Employees");
        }
    }
}
