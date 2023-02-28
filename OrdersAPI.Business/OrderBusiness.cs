using OrdersAPI.Data.DTOs;
using OrdersAPI.Data.Repository;
using OrdersAPI.Utils;
using System.Collections.Generic;

namespace OrdersAPI.Business
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogWriter _log;

        public OrderBusiness(ILogWriter log, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _log = log;
        }

        public async Task<List<OrderDTO>> GetOrderTotalItemsAsync(long customerId)
        {
            try
            {
                var orderModel = await _orderRepository.GetOrderTotalItemsAsync(customerId);

                var orderDTO = new List<OrderDTO>();

                var ordersIds = orderModel.Select(p => p.Id).Distinct().ToList();

                foreach (var orderId in ordersIds)
                {
                    var itemDTO = new OrderDTO();
                    itemDTO.OrderCode = orderId;
                    itemDTO.Products = new List<ProductDTO>();
                    orderModel.Where(p => p.Id == orderId).ToList().ForEach(o => itemDTO.Products.Add(o.ToDTO()));

                    orderDTO.Add(itemDTO);
                }

                return orderDTO;
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}