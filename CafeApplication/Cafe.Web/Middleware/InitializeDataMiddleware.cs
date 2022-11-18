using Cafe.Domain;
using Cafe.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Web.Middleware
{
    public class InitializeDataMiddleware
    {
        private readonly RequestDelegate _next;

        public InitializeDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext,
                           CafeContext dbcontext)
        {
            IngridientsInitialize(dbcontext);
            DishesInitialize(dbcontext);
            ProfessionInitialize(dbcontext);
            EmployeesInitialize(dbcontext);
            ProvidersInitialize(dbcontext, 8);
            IngridientWarehouseInitialize(dbcontext, 200);
            OrderInitialize(dbcontext, 1000);
            OrderDishInitialize(dbcontext);
            IngridientsDishInitialize(dbcontext);
            RolesInitialize(httpContext).Wait();
            return _next(httpContext);
        }

        private void IngridientsInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.Ingridients.Any())
            {
                string[] ingridientNames = new string[] { "coffee", "milk", "tea", "sugar", "lemon", "water" };
                Ingridient[] ingridients = new Ingridient[ingridientNames.Length];
                for (int i = 0; i < ingridientNames.Length; i++)
                {
                    Ingridient newIngridient = new Ingridient();
                    newIngridient.Name = ingridientNames[i];
                    //newIngridient.Id = i + 1;
                    ingridients[i] = newIngridient;
                }
                dbcontext.Ingridients.AddRange(ingridients);
                dbcontext.SaveChanges();
            }
        }
        private void DishesInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.Dishes.Any())
            {
                string[] dishNames = new string[] { "milk coffee", "tea with sugar", "tea with lemon" };
                float[] dishCosts = new float[] { 3.1f, 2.3f, 2.7f };
                int[] cookingTimes = new int[] { 5, 3, 3 };
                Dish[] dishes = new Dish[dishNames.Length];
                for (int i = 0; i < dishNames.Length; i++)
                {
                    Dish newDish = new Dish();
                    newDish.Name = dishNames[i];
                    newDish.Cost = dishCosts[i];
                    newDish.CookingTime = cookingTimes[i];
                    dishes[i] = newDish;
                }

                dbcontext.Dishes.AddRange(dishes);
                dbcontext.SaveChanges();
            }

        }
        private void ProfessionInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.Professions.Any())
            {
                string[] names = new string[] { "cleaner", "manager", "cook", "cassier", "waiter" };
                Profession[] professions = new Profession[names.Length];
                for (int i = 0; i < professions.Length; i++)
                {
                    var newProfession = new Profession();
                    newProfession.Name = names[i];
                    professions[i] = newProfession;
                }
                dbcontext.AddRange(professions);
                dbcontext.SaveChanges();
            }
        }
        private void EmployeesInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.Employees.Any())
            {
                Profession[] professions = dbcontext.Professions.ToArray();
                Random rnd = new Random();
                Employee[] employees = new Employee[20];
                for (int i = 0; i < employees.Length; i++)
                {
                    Employee newEmployee = new Employee();
                    newEmployee.Profession = professions[rnd.Next(0, professions.Length)];
                    newEmployee.FirstName = "firstName" + rnd.Next(1, 20);
                    newEmployee.LastName = "lastName" + rnd.Next(1, 20);
                    newEmployee.MiddleName = "middleName" + rnd.Next(1, 20);
                    newEmployee.Age = rnd.Next(18, 64);
                    newEmployee.Education = "education" + rnd.Next(0, 5);
                    employees[i] = newEmployee;
                }
                dbcontext.AddRange(employees);
                dbcontext.SaveChanges();
            }
        }
        private void ProvidersInitialize(CafeContext dbcontext, int providersCount)
        {
            if (!dbcontext.Providers.Any())
            {
                Provider[] providers = new Provider[providersCount];
                for (int i = 0; i < providersCount; i++)
                {
                    var newProvider = new Provider();
                    newProvider.Name = "provider" + i;
                    providers[i] = newProvider;
                }
                dbcontext.Providers.AddRange(providers);
                dbcontext.SaveChanges();
            }
        }
        private void IngridientWarehouseInitialize(CafeContext dbcontext, int count)
        {
            if (!dbcontext.IngridientsWarehouses.Any())
            {
                Random rnd = new Random();
                int providersCount = dbcontext.Providers.Count();
                int ingridientsCount = dbcontext.Ingridients.Count();
                IngridientsWarehouse[] warehouses = new IngridientsWarehouse[count];

                for (int i = 0; i < count; i++)
                {
                    var newWarehouse = new IngridientsWarehouse();
                    newWarehouse.Cost = rnd.Next(100, 1000);
                    newWarehouse.Provider = dbcontext.Providers.ToList()[rnd.Next(0, providersCount)];
                    newWarehouse.ReleaseDate = new DateTime(rnd.Next(2021, 2023), rnd.Next(1, 13), rnd.Next(1, 29));
                    newWarehouse.Ingridient = dbcontext.Ingridients.ToList()[rnd.Next(0, ingridientsCount)];
                    var storageLife = newWarehouse.StorageLife;
                    storageLife.AddMonths(rnd.Next(5, 10));
                    newWarehouse.StorageLife = storageLife;
                    newWarehouse.Weight = rnd.Next(200, 1000);
                    warehouses[i] = newWarehouse;
                }
                dbcontext.AddRange(warehouses);
                dbcontext.SaveChanges();
            }
        }
        private void OrderInitialize(CafeContext dbcontext, int ordersCount)
        {
            if (!dbcontext.Orders.Any())
            {
                Random rnd = new Random();
                int employeeCount = dbcontext.Employees.Count();
                Order[] orders = new Order[ordersCount];
                for (int i = 0; i < ordersCount; i++)
                {
                    var newOrder = new Order();
                    newOrder.PaymentMethod = rnd.Next(0, 2);
                    newOrder.CustomerPhoneNumber = "+375" + rnd.Next(29, 45).ToString() + rnd.Next(1000000, 9999999).ToString();
                    newOrder.OrderDate = new DateTime(rnd.Next(2021, 2023), rnd.Next(1, 13), rnd.Next(1, 29));
                    newOrder.CustomerName = "customer" + rnd.Next(1, 100);
                    newOrder.Employee = dbcontext.Employees.ToList()[rnd.Next(0, employeeCount)];
                    if (DateTime.Now.Month == newOrder.OrderDate.Month &&
                        newOrder.OrderDate.Year == DateTime.Now.Year && newOrder.OrderDate.Day == DateTime.Now.Day)
                        newOrder.IsCompleted = 0;
                    else
                        newOrder.IsCompleted = 1;

                    orders[i] = newOrder;
                }
                dbcontext.AddRange(orders);
                dbcontext.SaveChanges();
            }
        }
        private void OrderDishInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.OrderDishes.Any())
            {
                Random rnd = new Random();
                List<OrderDish> orderDishes = new List<OrderDish>();

                for (int i = 0; i < dbcontext.Orders.Count(); i++)
                {
                    for (int j = 0; j < rnd.Next(1, 8); j++)
                    {
                        var newOrderDish = new OrderDish();
                        newOrderDish.Order = dbcontext.Orders.ToList()[i];
                        newOrderDish.Dish = dbcontext.Dishes.ToList()[rnd.Next(0, dbcontext.Dishes.Count())];
                        orderDishes.Add(newOrderDish);
                    }
                }

                dbcontext.AddRange(orderDishes);
                dbcontext.SaveChanges();
            }
        }
        private void IngridientsDishInitialize(CafeContext dbcontext)
        {
            if (!dbcontext.IngridientsDishes.Any())
            {
                Random rnd = new Random();
                Dictionary<Dish, string[]> ingridientsDishes = new Dictionary<Dish, string[]>
                {
                    { dbcontext.Dishes.ToArray()[0], new string[] { "milk", "coffee", "water" } },
                    { dbcontext.Dishes.ToArray()[1], new string[] { "tea", "sugar", "water" } },
                    { dbcontext.Dishes.ToArray()[2], new string[] { "tea", "lemon", "water" } }
                };

                List<IngridientsDish> ingridientsDishForDb = new List<IngridientsDish>();
                foreach (KeyValuePair<Dish, string[]> item in ingridientsDishes)
                {
                    for (int i = 0; i < item.Value.Length; i++)
                    {
                        var ingridientDish = new IngridientsDish();
                        ingridientDish.Dish = item.Key;
                        ingridientDish.Ingridient = dbcontext.Ingridients.ToList().First(x => x.Name == item.Value[i]); ;
                        ingridientDish.IngridientWeight = rnd.Next(20, 101);
                        dbcontext.IngridientsDishes.Add(ingridientDish);
                    }

                    dbcontext.SaveChanges();
                }
            }
        }
        private async Task RolesInitialize(HttpContext context)
        {
            UserManager<IdentityUser> userManager = context.RequestServices.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = context.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
            string adminEmail = "admin@gmail.com";
            string adminName = adminEmail;

            string hostEmail = "host@gmail.com";
            string hostName = hostEmail;

            string adminPassword = "Admin1234_";
            string hostPassword = "Host1234_";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if(await roleManager.FindByNameAsync("host") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("host"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                IdentityUser admin = new IdentityUser
                {
                    Email = adminEmail,
                    UserName = adminName
                };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            if (await userManager.FindByNameAsync(hostName) == null)
            {
                IdentityUser host = new IdentityUser
                {
                    Email = hostEmail,
                    UserName = hostName
                };
                IdentityResult result = await userManager.CreateAsync(host, hostPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(host, "host");
                }
            }
        }
    }
}
