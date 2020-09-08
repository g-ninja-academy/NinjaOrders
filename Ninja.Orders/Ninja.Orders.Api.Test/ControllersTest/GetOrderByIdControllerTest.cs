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
    class GetOrderByIdControllerTest
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
        public void GetOrderById_WithOrderId_ReturnOrder()
        {
            _service.Setup(m => m.GetOrderById(It.IsAny<Guid>())).Returns(new Order());

            var result = _controller.GetOrderById(Guid.NewGuid()).Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ObjectResult>((ObjectResult) result.Result);
            Assert.AreEqual(StatusCodes.Status200OK, ((ObjectResult) result.Result).StatusCode);
            Assert.IsInstanceOf<Order>(((ObjectResult) result.Result).Value);
        }

        [Test]
        public void GetOrderById_WithoutOrderId_ReturnNotFound()
        {
            _service.Setup(m => m.GetOrderById(It.IsAny<Guid>())).Returns<Order>(default);

            var result = _controller.GetOrderById(default).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status404NotFound, ((StatusCodeResult)result.Result).StatusCode);
        }
    }
}