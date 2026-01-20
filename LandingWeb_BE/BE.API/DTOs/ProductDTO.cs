namespace BE.API.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ProductType { get; set; } = null!;
    public string? Category { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? LivePreviewUrl { get; set; }
    public List<ProductOptionDTO> Options { get; set; } = new();
    public List<string> Images { get; set; } = new();
}

public class ProductOptionDTO
{
    public int ProductOptionId { get; set; }
    public string OptionType { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
