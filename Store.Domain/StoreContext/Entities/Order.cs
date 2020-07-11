using System;
using System.Linq;
using System.Collections.Generic;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get { return _items.ToArray(); } }
        public IReadOnlyCollection<Delivery> Deliveries { get { return _deliveries.ToArray(); } }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }

        // To Place An Order
        public void Place()
        {

        }
    }
}