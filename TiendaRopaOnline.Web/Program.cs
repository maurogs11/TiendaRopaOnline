using Microsoft.EntityFrameworkCore;
using TiendaRopaOnline.Business.Business;
using TiendaRopaOnline.DataAccess.DataContext;
using TiendaRopaOnline.DataAccess.Repository;
using TiendaRopaOnline.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TiendaOnlineContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB"));
});

builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
