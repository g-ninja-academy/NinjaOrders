using Ninja.Orders.Application.Common.Interfaces;
using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Orders.Application.Services
{
    public class OrderService : IOrderService
    {
        List<Order> Orders;
        public OrderService()
        {
            Orders = new List<Order>();
        }

        public Order CreateOrder(IEnumerable<Product> products, Guid userId)
        {
            if (!products.Any() || userId == default(Guid))
                return null;           

            Order order = new Order
            {
                OrderId = Guid.NewGuid(),
                Products = products.ToList(),
                UserId = userId
            };
            Orders.Add(order);

            return order;
        }

        public Order GetOrderById(Guid orderId)
        {
            if (orderId == default(Guid))
                return null;

            return Orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public IEnumerable<Order> GetOrders()
        {
            return Orders;
        }
    }
}
