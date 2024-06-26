using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Helpers;
using ProductAPI.Repositories;
using ProductAPI.Repositories.Impl;
using ProductAPI.Services;
using ProductAPI.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  if (IsRelationalProvider(connectionString))
    options.UseSqlServer(connectionString);
  else
    options.UseInMemoryDatabase("ProductDatabase");
});

builder.Services.AddScoped<ProductQueryHelper>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  try
  {
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
  }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static bool IsRelationalProvider(string connectionString)
{
  return connectionString?.IndexOf("Server=", StringComparison.OrdinalIgnoreCase) >= 0;
}

public partial class Program { }