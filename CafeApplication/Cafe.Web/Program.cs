using Cafe.Application.Interfaces;
using Cafe.Persistence;
using Cafe.Web.Data;
using Cafe.Web.Middleware;
using Cafe.Web.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CafeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<ICafeDbContext, CafeContext>();
builder.Services.AddTransient<IngridientService>();
builder.Services.AddTransient<ProfessionService>();
builder.Services.AddTransient<ProviderService>();
builder.Services.AddTransient<DishService>();
builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<WarehouseService>();
builder.Services.AddMediatR(typeof(ICafeDbContext).Assembly);
builder.Services.AddResponseCaching();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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

//app.UseMiddleware<InitializeDataMiddleware>();


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
