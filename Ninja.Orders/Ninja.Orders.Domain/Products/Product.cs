using System;
using System.Collections.Generic;
using System.Text;

namespace Ninja.Orders.Domain.Products
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
