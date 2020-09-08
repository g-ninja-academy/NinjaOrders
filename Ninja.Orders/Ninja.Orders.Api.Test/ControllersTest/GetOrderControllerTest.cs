using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ninja.Orders.Api.Controllers;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Domain.Orders;
using NUnit.Framework;

namespace Ninja.Orders.Api.Test.ControllersTest
{
    [TestFixture]
    class GetOrderControllerTest
    {
        private Mock<IOrderService> _service;
        private OrderController _controller;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IOrderService>();
            _controller = new OrderController(_service.Object);
        }

        [Test]
        public void GetOrder_Successfully()
        {
            _service.Setup(m => m.GetOrders()).Returns(new List<Order>());

            var result = _controller.GetAllOrders().Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ObjectResult>((ObjectResult) result.Result);
            Assert.AreEqual(StatusCodes.Status200OK, ((ObjectResult) result.Result).StatusCode);
            Assert.IsInstanceOf<List<Order>>(((ObjectResult) result.Result).Value);
        }
    }
}