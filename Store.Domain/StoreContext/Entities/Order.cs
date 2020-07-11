using System;
using System.Linq;
using FluentValidator;
using System.Collections.Generic;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
  public class Order : Notifiable
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

    public void AddItem(Product product, decimal quantity)
    {
      if (quantity > product.QuantityOnHand)
        AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

      var item = new OrderItem(product, quantity);
      _items.Add(item);
    }

    public void AddDelivery(Delivery delivery)
    {
      _deliveries.Add(delivery);
    }

    public void Place()
    {
      if (_items.Count == 0)
        AddNotification("Order", "Este pedido não possui itens");
    }

    public void Pay()
    {
      Status = EOrderStatus.Paid;
    }

    public void Ship()
    {
      // A cada 5 produtos é uma entrega
      var count = 1;
      var deliveries = new List<Delivery>();

      // Quebra as entregas
      foreach (var item in _items)
      {
        if (count == 5)
        {
          count = 0;
          deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
        }
        count++;
      }

      // Envia todas as entregas
      deliveries.ForEach(x => x.Ship());

      // Adiciona as entregas ao pedido
      deliveries.ForEach(d => _deliveries.Add(d));
    }

    public void Cancel()
    {
      Status = EOrderStatus.Canceled;
      _deliveries.ToList().ForEach(d => d.Cancel());
    }
  }
}