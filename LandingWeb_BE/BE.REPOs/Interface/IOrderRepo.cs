using BE.BOs.Models;

namespace BE.REPOs.Interface;

public interface IOrderRepo
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order> CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
}
