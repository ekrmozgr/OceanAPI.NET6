using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<List<Order>> GetOrdersByUserId(int userId);
    }
}
