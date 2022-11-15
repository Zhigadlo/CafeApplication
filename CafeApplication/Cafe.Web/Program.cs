using Cafe.Application.Interfaces;
using Cafe.Persistence;
using Cafe.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CafeContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CafeContext>();

builder.Services.AddTransient<ICafeDbContext, CafeContext>();
builder.Services.AddTransient<IngridientService>();
builder.Services.AddTransient<DishService>();
builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<WarehouseService>();
builder.Services.AddMediatR(typeof(ICafeDbContext).Assembly);
builder.Services.AddResponseCaching();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dishes}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
