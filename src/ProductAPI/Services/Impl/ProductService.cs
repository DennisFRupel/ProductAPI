using ProductAPI.Dtos;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services.Impl;

public class ProductService : IProductService
{
  private readonly IProductRepository _productRepository;

  public ProductService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }

  public async Task<IEnumerable<Product>> GetAllAsync(ProductFilterDto filter)
  {
    return await _productRepository.GetAllAsync(filter);
  }

  public async Task<Product?> GetByIdAsync(long id)
  {
    return await _productRepository.GetByIdAsync(id);
  }

  public async Task<Product> AddAsync(Product product)
  {
    return await _productRepository.AddAsync(product);
  }

  public async Task<Product> UpdateAsync(Product product)
  {
    return await _productRepository.UpdateAsync(product);
  }

  public async Task DeleteAsync(long id)
  {
    await _productRepository.DeleteAsync(id);
  }
}