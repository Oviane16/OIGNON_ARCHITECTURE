using Microsoft.EntityFrameworkCore;
using PRODUCT.DAL;
using PRODUCT.DAL.Repository.Interfaces;
using PRODUCT.DAL.Repository;
using PRODUCT.DL.Entities;
using PRODUCT.BLL.Services.Interfaces;
using PRODUCT.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region services
builder.Services.AddScoped<IProductService, ProductService>();
#endregion

#region repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

#endregion


builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PRODUCT.DAL"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
