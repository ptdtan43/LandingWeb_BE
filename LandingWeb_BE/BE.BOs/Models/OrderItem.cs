namespace BE.BOs.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductOptionId { get; set; }
    public decimal Price { get; set; }
    public string? LicenseKey { get; set; }
    public string? DownloadUrl { get; set; }
    public string? DeploymentInfo { get; set; }
    public string? CustomizationRequest { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Processing, Completed

    public virtual Order Order { get; set; } = null!;
    public virtual ProductOption ProductOption { get; set; } = null!;
}
