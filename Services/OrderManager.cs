using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<List<Order>> GetOrdersByUserId(int id)
        {
            return await _orderRepository.GetOrdersByUserId(id);
        }
    }
}
