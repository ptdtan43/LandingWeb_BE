namespace BE.BOs.Models;

public class ProductOption
{
    public int ProductOptionId { get; set; }
    public int ProductId { get; set; }
    public string OptionType { get; set; } = null!; // SourceCode, Deploy, Customize
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsAvailable { get; set; } = true;

    public virtual Product Product { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
