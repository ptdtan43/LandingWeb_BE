using BE.BOs.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.DAOs;

public class OrderDAO
{
    private readonly AppDbContext _context;

    public OrderDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync() => 
        await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ProductOption)
            .ThenInclude(po => po.Product)
            .ToListAsync();

    public async Task<Order?> GetByIdAsync(int id) => 
        await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ProductOption)
            .ThenInclude(po => po.Product)
            .FirstOrDefaultAsync(o => o.OrderId == id);

    public async Task<List<Order>> GetByUserIdAsync(int userId) => 
        await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ProductOption)
            .Where(o => o.UserId == userId)
            .ToListAsync();

    public async Task<Order> CreateAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
