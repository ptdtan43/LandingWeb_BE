namespace BE.BOs.Models;

public class BusinessVerification
{
    public int BusinessVerificationId { get; set; }
    public int UserId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string TaxCode { get; set; } = null!;
    public string? Address { get; set; }
    public string? LegalDocumentUrl { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    public int? ReviewedByStaffId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReviewedAt { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual User? ReviewedByStaff { get; set; }
}
