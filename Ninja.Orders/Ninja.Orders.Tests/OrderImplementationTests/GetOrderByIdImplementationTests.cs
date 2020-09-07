using Ninja.Orders.Application.Services;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Orders.Application.Tests.OrderImplementationTests
{
    [TestFixture]
    public class GetOrderByIdImplementationTests
    {
        private readonly OrderService _orderService;
        private Guid orderId;
        public GetOrderByIdImplementationTests()
        {
            _orderService = new OrderService();
        }

        [SetUp]
        public void Setup()
        {
            var products = new List<Product>
                    {
                        new Product
                        {
                            ProductId = Guid.NewGuid(),
                            Price = (decimal)10.1,
                            Quantity = 1
                        }
                    };

            orderId = _orderService.CreateOrder(products, new Guid("f5d958ec-d760-4abe-bf3e-c8ba12c975e6")).OrderId;
        }

        [Test]
        public void GetOrderById_Successfully()
        {
            var result = _orderService.GetOrderById(orderId);
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Order>(result);
        }
        [Test]
        public void GetOrderById_NotOrderIdFail()
        {
            var result = _orderService.GetOrderById(default);
            Assert.IsNull(result);            
        }
        [Test]
        public void GetOrderById_OrderNotExistsFail()
        {
            var result = _orderService.GetOrderById(new Guid("f5d958ec-d760-4abe-bf3e-c8ba12c975e6"));
            Assert.IsNull(result);
        }
    }
}
