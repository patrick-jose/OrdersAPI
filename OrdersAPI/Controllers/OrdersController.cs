using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Business;
using OrdersAPI.Data.DTOs;
using OrdersAPI.Data.Repository;
using OrdersAPI.Utils;

namespace OrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderBusiness _orderBusiness;
        private readonly ILogWriter _log;

        public OrdersController(ILogWriter logger, IOrderRepository orderRepository, IOrderBusiness orderBusiness)
        {
            _log = logger;
            _orderRepository = orderRepository;
            _orderBusiness = orderBusiness;
        }

        [HttpGet("GetTotalOrderValue/{orderId}")]
        public async Task<decimal> GetTotalOrderValue(long orderId)
        {
            return await _orderRepository.GetOrderTotalValueAsync(orderId);
        }

        [HttpGet("GetOrderTotal/{customerId}")]
        public async Task<int> GetOrderTotalAsync(long customerId)
        {
            return await _orderRepository.GetOrderTotalAsync(customerId);
        }

        [HttpGet("GetOrderTotalItems/{customerId}")]
        public async Task<IEnumerable<OrderDTO>> GetOrderTotalItemsAsync(long customerId)
        {
            return await _orderBusiness.GetOrderTotalItemsAsync(customerId);
        }
    }
}