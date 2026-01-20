using BE.BOs.Models;
using Microsoft.EntityFrameworkCore;

namespace BE.DAOs;

public class TicketDAO
{
    private readonly AppDbContext _context;

    public TicketDAO(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetAllAsync() => 
        await _context.Tickets
            .Include(t => t.User)
            .Include(t => t.TicketReplies)
            .ToListAsync();

    public async Task<Ticket?> GetByIdAsync(int id) => 
        await _context.Tickets
            .Include(t => t.User)
            .Include(t => t.TicketReplies)
            .FirstOrDefaultAsync(t => t.TicketId == id);

    public async Task<List<Ticket>> GetByUserIdAsync(int userId) => 
        await _context.Tickets
            .Include(t => t.TicketReplies)
            .Where(t => t.UserId == userId)
            .ToListAsync();

    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }
}
