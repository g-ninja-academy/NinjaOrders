using System;
using System.Collections.Generic;
using System.Text;
using Ninja.Orders.Domain.Products;

namespace Ninja.Orders.Application.Models.Order
{
    public class CreateOrderVm
    {
        public List<Product> Products { get; set; }
        public Guid UserId { get; set; }
    }
}
