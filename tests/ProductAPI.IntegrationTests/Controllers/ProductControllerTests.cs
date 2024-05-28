using ProductAPI.IntegrationTests.Utils;
using ProductAPI.Models;
using System.Net.Http.Json;

namespace ProductAPI.IntegrationTests.Controllers;

public class ProductControllerTests
{
  [Fact]
  public async Task GetAll_ReturnsSuccessStatusCode()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync("/api/product");

    response.EnsureSuccessStatusCode();

    var products = await response.GetJson<List<Product>>();

    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(products);
    Assert.Equal(10, products.Count);
  }

  [Fact]
  public async Task GetById_ReturnsProduct()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync("/api/product/1");

    response.EnsureSuccessStatusCode();

    var product = await response.GetJson<Product>();

    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    Assert.NotNull(product);
    Assert.Equal(1, product.Id);
  }

  [Fact]
  public async Task GetById_NotFound()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync("/api/product/111");

    Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
  }

  [Fact]
  public async Task Create_AddsProduct()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var newProduct = new Product { Name = "Teste de integração", Stock = 5, Price = 10.5m };

    var response = await client.PostAsJsonAsync("/api/product", newProduct);

    response.EnsureSuccessStatusCode();

    var createdProduct = await response.GetJson<Product>();

    Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
    Assert.NotNull(createdProduct);
    Assert.Equal("Teste de integração", createdProduct.Name);
  }

  [Fact]
  public async Task Create_NegativePrice()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var newProduct = new Product { Id = 11, Name = "Test", Stock = 5, Price = -10m };

    var response = await client.PostAsJsonAsync("/api/product", newProduct);

    Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
  }

  [Fact]
  public async Task Update_UpdatesProduct()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var updatedProduct = new Product { Id = 1, Name = "Updated Integration Product", Stock = 10, Price = 15.5m };

    var response = await client.PutAsJsonAsync("/api/product/1", updatedProduct);

    response.EnsureSuccessStatusCode();

    Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
  }

  [Fact]
  public async Task Delete_DeletesProduct()
  {
    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.DeleteAsync("/api/product/1");

    response.EnsureSuccessStatusCode();

    Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
  }
}