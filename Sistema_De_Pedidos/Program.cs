using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sistema_De_Pedidos.Data;
using Sistema_De_Pedidos.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<BaseContext>
//(options => options.UseSqlServer("Data Source=LEONARDO\\SQLEXPRESS;Initial Catalog=SistemaDeProdutos;Integrated Security=True; Encrypt=false"));

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Homologation")));
ConfigurationService(builder);
//ESTE FUNCIONA!!!!!

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void ConfigurationService(WebApplicationBuilder builder)
{
    builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
}