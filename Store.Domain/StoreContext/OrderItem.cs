using System;

namespace Store.Domain.StoreContext
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public Product Quantity { get; set; }
        public Product Price { get; set; }
    }
}