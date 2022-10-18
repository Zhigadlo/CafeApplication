using Cafe.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Interfaces
{
    public interface ICafeDbContext
    {
        DbSet<Dish> Dishes { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Ingridient> Ingridients { get; set; }
        DbSet<IngridientsDish> IngridientsDishes { get; set; }
        DbSet<IngridientsWarehouse> IngridientsWarehouses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDish> OrderDishes { get; set; }
        DbSet<Profession> Professions { get; set; }
        DbSet<Provider> Providers { get; set; }
    }
}
