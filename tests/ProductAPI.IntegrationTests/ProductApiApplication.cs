using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using ProductAPI.Data;

namespace ProductAPI.IntegrationTests;
public class ProductApiApplication : WebApplicationFactory<Program>
{
  protected override IHost CreateHost(IHostBuilder builder)
  {
    var root = new InMemoryDatabaseRoot();

    builder.ConfigureServices(services =>
    {
      services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));
      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("ProductDatabase", root));
    });

    return base.CreateHost(builder);
  }

  public static async Task<HttpClient> SetupClientWithMockData()
  {
    var application = new ProductApiApplication();
    await ProductMockData.CreateProducts(application, true);
    return application.CreateClient();
  }
}
