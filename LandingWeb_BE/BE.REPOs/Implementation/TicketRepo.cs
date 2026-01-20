using BE.BOs.Models;
using BE.DAOs;
using BE.REPOs.Interface;

namespace BE.REPOs.Implementation;

public class TicketRepo : ITicketRepo
{
    private readonly TicketDAO _dao;

    public TicketRepo(TicketDAO dao)
    {
        _dao = dao;
    }

    public async Task<List<Ticket>> GetAllTicketsAsync() => await _dao.GetAllAsync();
    public async Task<Ticket?> GetTicketByIdAsync(int id) => await _dao.GetByIdAsync(id);
    public async Task<List<Ticket>> GetTicketsByUserIdAsync(int userId) => await _dao.GetByUserIdAsync(userId);
    public async Task<Ticket> CreateTicketAsync(Ticket ticket) => await _dao.CreateAsync(ticket);
    public async Task UpdateTicketAsync(Ticket ticket) => await _dao.UpdateAsync(ticket);
}
