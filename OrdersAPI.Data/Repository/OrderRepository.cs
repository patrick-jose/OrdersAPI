using Dapper;
using Npgsql;
using OrdersAPI.Data.Models;
using OrdersAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5455;" +
                   "Username=postgresUser;" +
                   "Password=postgresPW;" +
                   "Database=OrdersDB";

        private readonly NpgsqlConnection connection;
        private readonly ILogWriter _log;

        public OrderRepository(ILogWriter log)
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
            _log = log;
        }

        public async Task<decimal> GetOrderTotalValueAsync(long orderId)
        {
            try
            {
                string commandText = @$"select sum(co.quantity * co.unitaryprice) as result from orders.customerorder co 
                                        where co.orderid = @id;";

                var queryArgs = new { id = orderId };

                return await connection.QueryFirstOrDefaultAsync<decimal>(commandText, queryArgs);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<int> GetOrderTotalAsync(long customerId)
        {
            try
            {
                string commandText = @$"select count(*) from orders.customerorder co
                                        where co.customerid = @id;";

                var queryArgs = new { id = customerId };

                return await connection.QueryFirstOrDefaultAsync<int>(commandText, queryArgs);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }

        public async Task<IEnumerable<OrderModel>> GetOrderTotalItemsAsync(long customerId)
        {
            try
            {
                string commandText = @$"select  co.orderid as id, 
                                                co.customerid, 
                                                co.quantity, 
                                                co.unitaryprice as price, 
                                                p.""name"" as productName
                                        from orders.customerorder co
                                        inner join orders.product p 
                                        on p.id = co.productid 
                                        where co.customerid = @id;";

                var queryArgs = new { id = customerId };

                return await connection.QueryAsync<OrderModel>(commandText, queryArgs);
            }
            catch (Exception ex)
            {
                _log.LogWrite(ex.Message);
                throw ex;
            }
        }
    }
}
