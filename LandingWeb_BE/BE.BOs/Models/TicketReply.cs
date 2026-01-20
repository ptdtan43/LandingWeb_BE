namespace BE.BOs.Models;

public class TicketReply
{
    public int TicketReplyId { get; set; }
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public virtual Ticket Ticket { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
