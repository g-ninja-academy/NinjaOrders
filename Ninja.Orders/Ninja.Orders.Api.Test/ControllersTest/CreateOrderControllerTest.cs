using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ninja.Orders.Api.Controllers;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Application.Models.Order;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using NUnit.Framework;

namespace Ninja.Orders.Api.Test.ControllersTest
{
    [TestFixture]
    public class CreateOrderControllerTest
    {
        private Mock<IOrderService> _service;
        private OrderController _controller;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IOrderService>();
            _controller = new OrderController(_service.Object);
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
                            Price = (decimal) 10.1,
                            Quantity = 1
                        }
                    },
                    UserId = new Guid("f5d958ec-d760-4abe-bf3e-c8ba12c975e6")
                }
            };
        }


        [Test, TestCaseSource("GetOrder")]
        public void CreateOrder_SuccessfullyCreated_ReturnsOrder(Order order)
        {
            _service.Setup(m => m.CreateOrder(It.IsAny<IEnumerable<Product>>(), It.IsAny<Guid>())).Returns(new Order());

            var result = _controller.CreateOrder(new CreateOrderVm() { Products = order.Products, UserId = order.UserId }).Result;

            Assert.IsNotNull(result);

            Assert.IsInstanceOf<ObjectResult>((ObjectResult) result.Result);

            Assert.AreEqual(StatusCodes.Status200OK, ((ObjectResult) result.Result).StatusCode);

            Assert.IsInstanceOf<Order>(((ObjectResult) result.Result).Value);
        }

        [Test, TestCaseSource("GetOrder")]
        public void CreateOrder_WithoutProductsNotCreated_ReturnsBadRequest(Order order)
        {
            _service.Setup(m => m.CreateOrder(It.IsAny<IEnumerable<Product>>(), It.IsAny<Guid>()))
                .Returns<Order>(default);

            var result = _controller.CreateOrder(new CreateOrderVm() { Products = new List<Product>(), UserId = order.UserId }).Result;

            Assert.IsNotNull(result);

            Assert.AreEqual(StatusCodes.Status400BadRequest, ((StatusCodeResult) result.Result).StatusCode);
        }

        [Test, TestCaseSource("GetOrder")]
        public void CreateOrder_WithoutUserIdNotCreated_ReturnsBadRequest(Order order)
        {
            _service.Setup(m => m.CreateOrder(It.IsAny<IEnumerable<Product>>(), It.IsAny<Guid>()))
                .Returns<Order>(default);

            var result = _controller.CreateOrder(new CreateOrderVm() { Products = order.Products, UserId = order.UserId }).Result;

            Assert.IsNotNull(result);

            Assert.AreEqual(StatusCodes.Status400BadRequest, ((StatusCodeResult)result.Result).StatusCode);
        }
    }
}