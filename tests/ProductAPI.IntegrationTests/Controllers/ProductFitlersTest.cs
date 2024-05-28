using ProductAPI.Dtos;
using ProductAPI.IntegrationTests.Utils;
using ProductAPI.Models;

namespace ProductAPI.IntegrationTests.Controllers;
public class ProductFitlersTest
{
  [Fact]
  public async Task SearchByName_ReturnsMatchingProducts()
  {
    var filter = new ProductFilterDto { Name = "Celular" };
    var requestUri = $"/api/product?name={filter.Name}";

    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync(requestUri);

    response.EnsureSuccessStatusCode();

    var products = await response.GetJson<List<Product>>();

    Assert.NotNull(products);
    Assert.Single(products);
    Assert.Equal("Celular", products.ElementAt(0).Name);
  }

  [Fact]
  public async Task SortByName_ReturnsSortedProducts()
  {
    var filter = new ProductFilterDto { SortBy = "name" };
    var requestUri = $"/api/product?sortBy={filter.SortBy}";

    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync(requestUri);

    response.EnsureSuccessStatusCode();

    var products = await response.GetJson<List<Product>>();

    Assert.NotNull(products);
    Assert.NotEmpty(products);
    Assert.True(products[0].Name.CompareTo(products[1].Name) <= 0);
  }

  [Fact]
  public async Task SortByName_ReturnsDescendingSortedProducts()
  {
    var filter = new ProductFilterDto { SortBy = "name", Ascending = false };
    var requestUri = $"/api/product?sortBy={filter.SortBy}&ascending={filter.Ascending}";

    var client = await ProductApiApplication.SetupClientWithMockData();
    var response = await client.GetAsync(requestUri);

    response.EnsureSuccessStatusCode();

    var products = await response.GetJson<List<Product>>();

    Assert.NotNull(products);
    Assert.NotEmpty(products);
    Assert.True(products[0].Name.CompareTo(products[1].Name) >= 0);
  }
}
