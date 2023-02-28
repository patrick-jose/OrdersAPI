using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Data.DTOs
{
    public class OrderDTO
    {
        public long OrderCode { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
