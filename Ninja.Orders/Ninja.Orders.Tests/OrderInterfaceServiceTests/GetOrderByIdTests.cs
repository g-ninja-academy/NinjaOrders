using Moq;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Orders.Application.Tests.OrderInterfaceServiceTests
{
    [TestFixture]
    public class GetOrderByIdTests
    {
        Mock<IOrderService> _orderService;

        [SetUp]
        public void SetUp()
        {
            _orderService = new Mock<IOrderService>();
        }
        public Order GetOrder()
        {
            return new Order
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
            };
        }
        [Test]
        public void GetOrderById_Successfully()
        {
            _orderService.Setup(x => x.GetOrderById(It.IsAny<Guid>())).Returns(GetOrder());

            var result = _orderService.Object.GetOrderById(Guid.NewGuid());

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Order>(result);
        }
        [Test]
        public void GetOrderById_NotFound()
        {
            _orderService.Setup(x => x.GetOrderById(It.IsAny<Guid>())).Returns<Order>(default);

            var result = _orderService.Object.GetOrderById(Guid.NewGuid());

            Assert.IsNull(result);
        }

    }
}
