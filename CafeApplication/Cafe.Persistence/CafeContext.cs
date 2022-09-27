using Cafe.Domain;
using Cafe.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Persistence
{
    public class CafeContext : DbContext
    {
        public CafeContext()
        {
        }

        public CafeContext(DbContextOptions<CafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Ingridient> Ingridients { get; set; } = null!;
        public virtual DbSet<IngridientsDish> IngridientsDishes { get; set; } = null!;
        public virtual DbSet<IngridientsWarehouse> IngridientsWarehouses { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDish> OrderDishes { get; set; } = null!;
        public virtual DbSet<Profession> Professions { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(DatabaseConnection.Instance.GetConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new IngridientConfiguration());
            modelBuilder.ApplyConfiguration(new IngridientDishConfiguration());
            modelBuilder.ApplyConfiguration(new IngridientsWarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDishConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
