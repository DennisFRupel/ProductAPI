using ProductAPI.Dtos;
using ProductAPI.Models;

namespace ProductAPI.Repositories;

public interface IProductRepository
{
  Task<List<Product>> GetAllAsync(ProductFilterDto filter);
  Task<Product?> GetByIdAsync(long id);
  Task<Product> AddAsync(Product product);
  Task<Product> UpdateAsync(Product product);
  Task DeleteAsync(long id);
}