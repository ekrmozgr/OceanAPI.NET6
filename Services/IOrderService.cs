using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<List<Order>> GetOrdersByUserId(int id);
    }
}
