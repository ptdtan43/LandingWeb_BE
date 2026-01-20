using BE.BOs.Models;

namespace BE.REPOs.Interface;

public interface ITicketRepo
{
    Task<List<Ticket>> GetAllTicketsAsync();
    Task<Ticket?> GetTicketByIdAsync(int id);
    Task<List<Ticket>> GetTicketsByUserIdAsync(int userId);
    Task<Ticket> CreateTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
}
