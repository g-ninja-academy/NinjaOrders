using Ninja.Orders.Application.Services;
using Ninja.Orders.Domain.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Orders.Application.Tests.OrderImplementationTests
{
    [TestFixture]
    public class GetAllOrdersImplementationTests
    {
        private readonly OrderService _orderservice;

        public GetAllOrdersImplementationTests()
        {
            _orderservice = new OrderService();
        }
        [Test]
        public void GetAllOrders_Successfully()
        {
            var result = _orderservice.GetOrders();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Order>>(result);
        }
    }
}
