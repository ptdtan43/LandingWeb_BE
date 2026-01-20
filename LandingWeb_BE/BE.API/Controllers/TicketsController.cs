using System.Security.Claims;
using BE.API.DTOs;
using BE.BOs.Models;
using BE.REPOs.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BE.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TicketsController : ControllerBase
{
    private readonly ITicketRepo _ticketRepo;

    public TicketsController(ITicketRepo ticketRepo)
    {
        _ticketRepo = ticketRepo;
    }

    [HttpGet("my-tickets")]
    public async Task<IActionResult> GetMyTickets()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        var tickets = await _ticketRepo.GetTicketsByUserIdAsync(userId);

        var result = tickets.Select(t => new TicketDTO
        {
            TicketId = t.TicketId,
            Subject = t.Subject,
            Status = t.Status,
            CreatedAt = t.CreatedAt
        });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequest request)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

        var ticket = new Ticket
        {
            UserId = userId,
            Subject = request.Subject,
            Message = request.Message,
            Status = "Open"
        };

        await _ticketRepo.CreateTicketAsync(ticket);
        return Ok(new { message = "Ticket created successfully", ticketId = ticket.TicketId });
    }
}
