using OrdersAPI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Data.Models
{
    public class OrderModel
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }

        public ProductDTO ToDTO()
        {
            var resultDTO = new ProductDTO()
            {
                Name = this.ProductName, Price = this.Price, Quantity = this.Quantity
            };

            return resultDTO;
        }
    }
}
