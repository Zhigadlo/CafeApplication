using Cafe.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cafe.Persistence.EntityTypeConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Employee__3214EC07111A9BE4");
            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.FirstName).HasMaxLength(20).IsUnicode(false).HasColumnOrder(1);
            builder.Property(e => e.LastName).HasMaxLength(20).IsUnicode(false).HasColumnOrder(2);
            builder.Property(e => e.MiddleName).HasMaxLength(20).IsUnicode(false).HasColumnOrder(3);
            builder.Property(e => e.Age).HasColumnOrder(4).HasDefaultValueSql("((18))");
            builder.Property(e => e.Education).HasMaxLength(50).IsUnicode(false).HasColumnOrder(5);
            builder.Property(e => e.ProfessionId).HasColumnOrder(6);
            builder.HasOne(d => d.Profession).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProfessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_To_Professions");
        }
    }
}
