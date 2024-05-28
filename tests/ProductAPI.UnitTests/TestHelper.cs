using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Helpers;
using ProductAPI.Repositories.Impl;
using ProductAPI.Services;
using ProductAPI.Services.Impl;

namespace ProductAPI.UnitTests;

public class TestHelper
{
  public static async Task<IProductService> GetProductService()
  {
    var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

    var dbContext = new ApplicationDbContext(dbContextOptions);
    dbContext.Database.EnsureCreated();
    //await SeedTestDataAsync(dbContext);

    var queryHelper = new ProductQueryHelper();
    var repository = new ProductRepository(dbContext, queryHelper);
    var service = new ProductService(repository);
    return service;
  }

  private static async Task SeedTestDataAsync(ApplicationDbContext dbContext)
  {
    var products = ApplicationDbContext.GetProductsData();
    await dbContext.Products.AddRangeAsync(products);
    await dbContext.SaveChangesAsync();
  }
}
