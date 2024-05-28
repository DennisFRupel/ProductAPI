using ProductAPI.Dtos;
using ProductAPI.Models;
using System.Linq.Expressions;

namespace ProductAPI.Helpers;

public class ProductQueryHelper
{
  private static Dictionary<string, Expression<Func<Product, object>>> _Expressao = new()
  {
    ["name"] = p => p.Name,
    ["stock"] = p => p.Stock,
    ["price"] = p => p.Price,
  };

  public IQueryable<Product> ApplyFilters(IQueryable<Product> query, ProductFilterDto filter)
  {
    filter ??= new ProductFilterDto();

    if (!string.IsNullOrEmpty(filter.Name))
      query = query.Where(p => p.Name.Contains(filter.Name));

    if (filter.MaxStock.HasValue)
      query = query.Where(p => p.Stock <= filter.MaxStock.Value);

    if (filter.MinStock.HasValue)
      query = query.Where(p => p.Stock >= filter.MinStock.Value);

    if (filter.MaxPrice.HasValue)
      query = query.Where(p => p.Price <= filter.MaxPrice.Value);

    if (filter.MinPrice.HasValue)
      query = query.Where(p => p.Price >= filter.MinPrice.Value);

    return query;
  }

  public IQueryable<Product> ApplySorting(IQueryable<Product> query, string sortBy, bool ascending = true)
  {
    sortBy = sortBy.ToLower();
    var order = _Expressao.TryGetValue(sortBy, out var value) ? value : p => p.Id;
    return ascending ? query.OrderBy(order) : query.OrderByDescending(order);
  }
}