using Ninja.Orders.Domain.Orders;
using Ninja.Orders.Domain.Products;
using System;
using System.Collections.Generic;

namespace Ninja.Orders.Application.Common.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(IEnumerable<Product> products, Guid userId);
        IEnumerable<Order> GetOrders();
        Order GetOrderById(Guid orderId);
    }
}