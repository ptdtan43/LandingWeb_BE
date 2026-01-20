namespace BE.API.DTOs;

public class CreateTicketRequest
{
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;
}

public class TicketDTO
{
    public int TicketId { get; set; }
    public string Subject { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
