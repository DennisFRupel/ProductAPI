using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;

namespace ProductAPI.IntegrationTests;
public class ProductMockData
{
  public static async Task CreateProducts(ProductApiApplication application, bool create)
  {
    using var scope = application.Services.CreateScope();
    var provider = scope.ServiceProvider;

    using var dbContext = provider.GetRequiredService<ApplicationDbContext>();
    await dbContext.Database.EnsureCreatedAsync();

    if (create && !dbContext.Products.Any())
    {
      var productsData = ApplicationDbContext.GetProductsData();
      dbContext.Products.AddRange(productsData);
      await dbContext.SaveChangesAsync();
    }
  }
}
