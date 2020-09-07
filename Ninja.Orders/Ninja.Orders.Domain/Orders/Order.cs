using Ninja.Orders.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Orders.Domain.Orders
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public List<Product> Products { get; set; }
        public Guid UserId { get; set; }
    }
}
