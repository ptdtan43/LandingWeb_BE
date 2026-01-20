using Microsoft.EntityFrameworkCore;

namespace BE.BOs.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOption> ProductOptions { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }
    public DbSet<UserVoucher> UserVouchers { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketReply> TicketReplies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<BusinessVerification> BusinessVerifications { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProductType).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductOption>(entity =>
        {
            entity.HasKey(e => e.ProductOptionId);
            entity.HasOne(e => e.Product).WithMany(p => p.ProductOptions).HasForeignKey(e => e.ProductId);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.HasOne(e => e.User).WithMany(u => u.Orders).HasForeignKey(e => e.UserId);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.FinalAmount).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
            entity.HasOne(e => e.Order).WithMany(o => o.OrderItems).HasForeignKey(e => e.OrderId);
            entity.HasOne(e => e.ProductOption).WithMany(po => po.OrderItems).HasForeignKey(e => e.ProductOptionId);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(5,2)");
            entity.Property(e => e.MaxDiscountAmount).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<UserVoucher>(entity =>
        {
            entity.HasKey(e => e.UserVoucherId);
            entity.HasOne(e => e.User).WithMany(u => u.UserVouchers).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Voucher).WithMany(v => v.UserVouchers).HasForeignKey(e => e.VoucherId);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId);
            entity.HasOne(e => e.User).WithMany(u => u.Tickets).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.AssignedToStaff).WithMany().HasForeignKey(e => e.AssignedToStaffId).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId);
            entity.HasOne(e => e.User).WithMany(u => u.Reviews).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Product).WithMany(p => p.Reviews).HasForeignKey(e => e.ProductId);
        });

        modelBuilder.Entity<BusinessVerification>(entity =>
        {
            entity.HasKey(e => e.BusinessVerificationId);
            entity.HasOne(e => e.User).WithOne(u => u.BusinessVerification).HasForeignKey<BusinessVerification>(e => e.UserId);
            entity.HasOne(e => e.ReviewedByStaff).WithMany().HasForeignKey(e => e.ReviewedByStaffId).OnDelete(DeleteBehavior.SetNull);
        });
    }
}
