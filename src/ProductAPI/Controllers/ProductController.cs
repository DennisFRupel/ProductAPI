using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dtos;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
  private readonly IProductService _productService = productService;

  [HttpGet] // api/product?name=Produto1&stock=10&price=100.00&sortBy=name&ascending=true
  public async Task<ActionResult<IEnumerable<Product>>> Get([FromQuery] ProductFilterDto filter)
  {
    var products = await _productService.GetAllAsync(filter);
    if (products == null || !products.Any()) 
    {
      return NotFound("Nenhum produto encontrado!");
    }

    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetById(long id)
  {
    var product = await _productService.GetByIdAsync(id);
    if (product == null)
    {
      return NotFound("Id não encontrado!");
    }
    return Ok(product);
  }

  [HttpPost]
  public async Task<ActionResult<Product>> Create(Product product)
  {
    if (0 > product.Price)
    {
      return BadRequest();
    }

    var createdProduct = await _productService.AddAsync(product);
    return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(long id, Product product)
  {
    if (id != product.Id || 0 > product.Price)
    {
      return BadRequest();
    }

    await _productService.UpdateAsync(product);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(long id)
  {
    await _productService.DeleteAsync(id);
    return NoContent();
  }
}