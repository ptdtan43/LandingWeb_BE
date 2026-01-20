namespace BE.BOs.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public int UserId { get; set; }
    public string Subject { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string Status { get; set; } = "Open"; // Open, InProgress, Resolved, Closed
    public int? AssignedToStaffId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual User? AssignedToStaff { get; set; }
    public virtual ICollection<TicketReply> TicketReplies { get; set; } = new List<TicketReply>();
}
