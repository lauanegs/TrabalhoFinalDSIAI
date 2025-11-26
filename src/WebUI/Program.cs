using Infrastructure.Data;
using Infrastructure.Repositories;
using Application.Interfaces;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Configuration and DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Server=localhost,1433;Database=InventoryControlDb;User Id=sa;Password=Senha123.;TrustServerCertificate=True;Encrypt=False;";

builder.Services.AddControllersWithViews();

var config = TypeAdapterConfig.GlobalSettings;
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

// DI - register DbContext and services/repositories
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// basic pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();