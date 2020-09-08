using Moq;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Orders.Application.Tests.OrderInterfaceServiceTests
{
    [TestFixture]
    public class GetOrdersTests
    {
        Mock<IOrderService> _orderService;

        [SetUp]
        public void SetUp()
        {
            _orderService = new Mock<IOrderService>();
        }
        public IEnumerable<Order> GetOrders()
        {
           return  Enumerable.Range(1,5).Select(x =>
            
                new Order()
                {
                    OrderId = Guid.NewGuid(),
                    Products = new List<Product>
                    {
                        new Product
                        {
                            ProductId = Guid.NewGuid(),
                            Price = (decimal)10.1,
                            Quantity = 1
                        }
                    },
                    UserId = Guid.NewGuid()
                }
            ).AsEnumerable();
        }
        [Test]
        public void GetAllOrders_SuccessFully()
        {
            _orderService.Setup(x => x.GetOrders()).Returns(GetOrders());

            var result = _orderService.Object.GetOrders();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Order>>(result);
        }
    }
}
