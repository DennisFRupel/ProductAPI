using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
  {
  }

  public DbSet<Product> Products { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Product>().HasData(GetProductsData());
  }

  public static List<Product> GetProductsData()
  {
    return
    [
        new Product { Id = 1, Name = "Celular", Stock = 50, Price = 2999.99m },
        new Product { Id = 2, Name = "Notebook", Stock = 30, Price = 4999.99m },
        new Product { Id = 3, Name = "Tablet", Stock = 20, Price = 1999.99m },
        new Product { Id = 4, Name = "Relógio Inteligente", Stock = 15, Price = 999.99m },
        new Product { Id = 5, Name = "Fone de Ouvido", Stock = 100, Price = 299.99m },
        new Product { Id = 6, Name = "Caixa de Som Bluetooth", Stock = 70, Price = 499.99m },
        new Product { Id = 7, Name = "Teclado", Stock = 40, Price = 149.99m },
        new Product { Id = 8, Name = "Mouse", Stock = 80, Price = 99.99m },
        new Product { Id = 9, Name = "Monitor", Stock = 25, Price = 899.99m },
        new Product { Id = 10, Name = "HD Externo", Stock = 60, Price = 399.99m }
    ];
  }
}