using ProductAPI.Models;
using ProductAPI.Data;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Dtos;
using ProductAPI.Helpers;

namespace ProductAPI.Repositories.Impl;

public class ProductRepository : IProductRepository
{
  private readonly ApplicationDbContext _context;
  private readonly ProductQueryHelper _productQueryHelper;

  public ProductRepository(ApplicationDbContext context, ProductQueryHelper productQueryHelper)
  {
    _context = context;
    _productQueryHelper = productQueryHelper;
  }

  public async Task<List<Product>> GetAllAsync(ProductFilterDto filter)
  {
    var query = _context.Products.AsQueryable();

    query = _productQueryHelper.ApplyFilters(query, filter);
    query = _productQueryHelper.ApplySorting(query, filter.SortBy, filter.Ascending);

    return await query.ToListAsync();
  }

  public async Task<Product?> GetByIdAsync(long id)
  {
    return await _context.Products.FindAsync(id);
  }

  public async Task<Product> AddAsync(Product product)
  {
    if (product.Price < 0)
    {
      throw new ArgumentException("O valor do produto não pode ser negativo.");
    }

    _context.Products.Add(product);
    await _context.SaveChangesAsync();
    return product;
  }

  public async Task<Product> UpdateAsync(Product product)
  {
    if (product.Price < 0)
    {
      throw new ArgumentException("O valor do produto não pode ser negativo.");
    }
    _context.Products.Update(product);
    await _context.SaveChangesAsync();
    return product;
  }

  public async Task DeleteAsync(long id)
  {
    var product = await _context.Products.FindAsync(id);
    if (product == null)
    {
      throw new ArgumentNullException(nameof(product), "Produto não encontrado");
    }
    _context.Products.Remove(product);
    await _context.SaveChangesAsync();
  }
}