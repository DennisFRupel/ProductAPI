using ProductAPI.Dtos;
using ProductAPI.Models;

namespace ProductAPI.Services;

public interface IProductService
{
  Task<IEnumerable<Product>> GetAllAsync(ProductFilterDto filter);
  Task<Product?> GetByIdAsync(long id);
  Task<Product> AddAsync(Product product);
  Task<Product> UpdateAsync(Product product);
  Task DeleteAsync(long id);
}