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
public class OrdersController : ControllerBase
{
    private readonly IOrderRepo _orderRepo;

    public OrdersController(IOrderRepo orderRepo)
    {
        _orderRepo = orderRepo;
    }

    [HttpGet("my-orders")]
    public async Task<IActionResult> GetMyOrders()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        var orders = await _orderRepo.GetOrdersByUserIdAsync(userId);

        var result = orders.Select(o => new OrderDTO
        {
            OrderId = o.OrderId,
            OrderCode = o.OrderCode,
            FinalAmount = o.FinalAmount,
            Status = o.Status,
            CreatedAt = o.CreatedAt,
            Items = o.OrderItems.Select(oi => new OrderItemDTO
            {
                OrderItemId = oi.OrderItemId,
                ProductName = oi.ProductOption.Product.Name,
                OptionType = oi.ProductOption.OptionType,
                Price = oi.Price,
                Status = oi.Status,
                LicenseKey = oi.LicenseKey,
                DownloadUrl = oi.DownloadUrl
            }).ToList()
        });

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderRepo.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound();

        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        if (order.UserId != userId && !User.IsInRole("Admin") && !User.IsInRole("Staff"))
            return Forbid();

        var result = new OrderDTO
        {
            OrderId = order.OrderId,
            OrderCode = order.OrderCode,
            FinalAmount = order.FinalAmount,
            Status = order.Status,
            CreatedAt = order.CreatedAt,
            Items = order.OrderItems.Select(oi => new OrderItemDTO
            {
                OrderItemId = oi.OrderItemId,
                ProductName = oi.ProductOption.Product.Name,
                OptionType = oi.ProductOption.OptionType,
                Price = oi.Price,
                Status = oi.Status,
                LicenseKey = oi.LicenseKey,
                DownloadUrl = oi.DownloadUrl
            }).ToList()
        };

        return Ok(result);
    }
}
