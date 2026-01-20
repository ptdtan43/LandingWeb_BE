using BE.BOs.Models;
using BE.DAOs;
using BE.REPOs.Interface;

namespace BE.REPOs.Implementation;

public class OrderRepo : IOrderRepo
{
    private readonly OrderDAO _dao;

    public OrderRepo(OrderDAO dao)
    {
        _dao = dao;
    }

    public async Task<List<Order>> GetAllOrdersAsync() => await _dao.GetAllAsync();
    public async Task<Order?> GetOrderByIdAsync(int id) => await _dao.GetByIdAsync(id);
    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId) => await _dao.GetByUserIdAsync(userId);
    public async Task<Order> CreateOrderAsync(Order order) => await _dao.CreateAsync(order);
    public async Task UpdateOrderAsync(Order order) => await _dao.UpdateAsync(order);
}
