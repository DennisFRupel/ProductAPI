using ProductAPI.Dtos;
using ProductAPI.Models;

namespace ProductAPI.UnitTests.Services;

public class ProductServiceTests
{
  [Fact]
  public async Task GetAllAsync_ReturnsAllProducts()
  {
    var productService = await TestHelper.GetProductService();
    
    var result = await productService.GetAllAsync(new ProductFilterDto());

    Assert.NotNull(result);
    Assert.Equal(10, result.Count());
  }

  [Fact]
  public async Task GetByIdAsync_ReturnsProduct()
  {
    var productService = await TestHelper.GetProductService();

    var result = await productService.GetByIdAsync(1);

    Assert.NotNull(result);
    Assert.Equal("Celular", result.Name);
  }

  [Fact]
  public async Task AddAsync_AddsProduct()
  {
    var productService = await TestHelper.GetProductService();

    var product = new Product { Name = "Test Product", Stock = 10, Price = 100m };
    var result = await productService.AddAsync(product);

    Assert.NotNull(result);
    Assert.Equal("Test Product", result.Name);
  }

  [Fact]
  public async Task UpdateAsync_UpdatesProduct()
  {
    var productService = await TestHelper.GetProductService();
    var product = new Product { Id = 1, Name = "Updated Product", Stock = 10, Price = 100m };

    var result = await productService.UpdateAsync(product);

    Assert.NotNull(result);
    Assert.Equal("Updated Product", result.Name);
  }

  [Fact]
  public async Task DeleteAsync_DeletesProduct()
  {
    var productService = await TestHelper.GetProductService();

    await productService.DeleteAsync(1);
    var result = await productService.GetByIdAsync(1);

    Assert.Null(result);
  }

  [Fact]
  public async Task SearchByNameAsync_ReturnsMatchingProducts()
  {
    var productService = await TestHelper.GetProductService();
    var filter = new ProductFilterDto() { Name = "Celular" };

    var result = await productService.GetAllAsync(filter);

    Assert.Single(result);
    Assert.Equal("Celular", result.ElementAt(0).Name);
  }

  [Fact]
  public async Task SortByFieldAsync_SortsProducts()
  {
    var productService = await TestHelper.GetProductService();
    var filter = new ProductFilterDto() { SortBy = "name" };

    var products = await productService.GetAllAsync(filter);

    Assert.NotNull(products);
    Assert.NotEmpty(products);
    Assert.True(products.ElementAt(0).Name.CompareTo(products.ElementAt(1).Name) <= 0);
  }
}
