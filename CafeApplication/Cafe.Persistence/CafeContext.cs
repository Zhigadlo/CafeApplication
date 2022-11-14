using Cafe.Application.Interfaces;
using Cafe.Domain;
using Cafe.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Persistence
{
    public class CafeContext : DbContext, ICafeDbContext
    {
        public CafeContext()
        {
            Database.EnsureCreated();
        }

        public CafeContext(DbContextOptions<CafeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Ingridient> Ingridients { get; set; } = null!;
        public DbSet<IngridientsDish> IngridientsDishes { get; set; } = null!;
        public DbSet<IngridientsWarehouse> IngridientsWarehouses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDish> OrderDishes { get; set; } = null!;
        public DbSet<Profession> Professions { get; set; } = null!;
        public DbSet<Provider> Providers { get; set; } = null!;

        public async Task Save()
        {
            await SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

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
