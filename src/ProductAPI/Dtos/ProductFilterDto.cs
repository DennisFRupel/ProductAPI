namespace ProductAPI.Dtos;

public class ProductFilterDto
{
  public string Name { get; set; } = string.Empty;
  public string SortBy { get; set; } = string.Empty;
  public bool Ascending { get; set; } = true;
  public decimal? MaxPrice { get; set; }
  public decimal? MinPrice { get; set; }
  public int? MaxStock { get; set; }
  public int? MinStock { get; set; }
}