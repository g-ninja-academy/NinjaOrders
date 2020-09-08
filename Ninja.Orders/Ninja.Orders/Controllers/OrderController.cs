using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Application.Models.Order;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;

namespace Ninja.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] CreateOrderVm order)
        {
            var result = _service.CreateOrder(order.Products, order.UserId);

            if (result == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var resutl = _service.GetOrders();

            return StatusCode(StatusCodes.Status200OK, resutl);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid orderId)
        {
            var result = _service.GetOrderById(orderId);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}