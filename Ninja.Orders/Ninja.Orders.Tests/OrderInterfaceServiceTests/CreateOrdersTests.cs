using Moq;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Domain.Products;
using Ninja.Orders.Domain.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Ninja.Orders.Application.Tests.OrderInterfaceServiceTests
{
    [TestFixture]
    public class CreateOrdersTests
    {
        Mock<IOrderService> _orderService;

        [SetUp]
        public void SetUp()
        {
            _orderService = new Mock<IOrderService>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Price = (decimal)10.1,
                    Quantity = 1
                }
            }.AsEnumerable();
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
        public void CreateOrder_Successfully()
        {
            _orderService.Setup(x => x.CreateOrder(It.IsAny<IEnumerable<Product>>(), It.IsAny<Guid>())).Returns(GetOrder());

            var result = _orderService.Object.CreateOrder(GetProducts(), Guid.NewGuid());


            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Order>(result);

        }
        [Test]
        public void CreateOrder_Fail()
        {
            _orderService.Setup(x => x.CreateOrder(It.IsAny<IEnumerable<Product>>(), It.IsAny<Guid>())).Returns<Order>(default);

            var result = _orderService.Object.CreateOrder(GetProducts(), Guid.NewGuid());

            Assert.IsNull(result);
        }
    }
}
