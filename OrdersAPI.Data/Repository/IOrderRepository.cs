using OrdersAPI.Data.Models;

namespace OrdersAPI.Data.Repository
{
    public interface IOrderRepository
    {
        Task<int> GetOrderTotalAsync(long customerId);
        Task<IEnumerable<OrderModel>> GetOrderTotalItemsAsync(long customerId);
        Task<decimal> GetOrderTotalValueAsync(long orderId);
    }
}