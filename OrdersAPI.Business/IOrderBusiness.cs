using OrdersAPI.Data.DTOs;

namespace OrdersAPI.Business
{
    public interface IOrderBusiness
    {
        Task<List<OrderDTO>> GetOrderTotalItemsAsync(long customerId);
    }
}