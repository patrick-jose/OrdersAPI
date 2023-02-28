using OrdersAPI.Data.Repository;
using OrdersAPI.Utils;

namespace OrdersAPI.Tests
{
    [TestClass]
    public class OrderTests
    {
        private IOrderRepository _ordersRepository;
        private ILogWriter _log;

        [TestMethod]
        public async Task GetOrderTotalValueAsyncTest()
        {
            _log = new LogWriter();
            _ordersRepository = new OrderRepository(_log);

            var result = await _ordersRepository.GetOrderTotalValueAsync(6);

            Assert.IsNotNull(result);
            Assert.AreEqual(60.10M, result);
        }

        [TestMethod]
        public async Task GetOrderTotalAsyncTest()
        {
            _log = new LogWriter();
            _ordersRepository = new OrderRepository(_log);

            var result = await _ordersRepository.GetOrderTotalAsync(3);

            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public async Task GetOrderTotalItemsAsyncTest()
        {
            _log = new LogWriter();
            _ordersRepository = new OrderRepository(_log);

            var result = await _ordersRepository.GetOrderTotalItemsAsync(3);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }
    }
}