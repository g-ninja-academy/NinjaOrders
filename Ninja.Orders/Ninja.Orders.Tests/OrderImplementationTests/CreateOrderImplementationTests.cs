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
    public class CreateOrderImplementationTests
    {
        private readonly OrderService _orderService;

        public CreateOrderImplementationTests()
        {
            _orderService = new OrderService();
        }

        public static List<Order> GetOrder()
        {
            return new List<Order>
            { 
                new Order()
                {
                    Products = new List<Product>
                    {
                        new Product
                        {
                            ProductId = Guid.NewGuid(),
                            Price = (decimal)10.1,
                            Quantity = 1
                        }
                    },
                    UserId = new Guid("f5d958ec-d760-4abe-bf3e-c8ba12c975e6")
                }
            };
        }


        [Test]
        [TestCaseSource("GetOrder")]
        public void CreateOrder_Successfully(Order order)
        {
            var result = _orderService.CreateOrder(order.Products.AsEnumerable(), order.UserId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Order>(result);
        }

        [Test]
        [TestCaseSource("GetOrder")]
        public void CreateOrder_WithoutProductsFail(Order order)
        {
            
            var result = _orderService.CreateOrder(new List<Product>(), order.UserId);

            Assert.IsNull(result);
        }

        [Test]
        [TestCaseSource("GetOrder")]
        public void CreateOrder_UseIdDefaultFail(Order order)
        {

            var result = _orderService.CreateOrder(order.Products.AsEnumerable(), default);

            Assert.IsNull(result);
        }

    }
}
