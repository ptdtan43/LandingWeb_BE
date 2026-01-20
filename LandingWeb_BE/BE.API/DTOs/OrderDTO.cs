namespace BE.API.DTOs;

public class CreateOrderRequest
{
    public int ProductOptionId { get; set; }
    public string? DeploymentInfo { get; set; }
    public string? CustomizationRequest { get; set; }
    public string? VoucherCode { get; set; }
}

public class OrderDTO
{
    public int OrderId { get; set; }
    public string OrderCode { get; set; } = null!;
    public decimal FinalAmount { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<OrderItemDTO> Items { get; set; } = new();
}

public class OrderItemDTO
{
    public int OrderItemId { get; set; }
    public string ProductName { get; set; } = null!;
    public string OptionType { get; set; } = null!;
    public decimal Price { get; set; }
    public string Status { get; set; } = null!;
    public string? LicenseKey { get; set; }
    public string? DownloadUrl { get; set; }
}
