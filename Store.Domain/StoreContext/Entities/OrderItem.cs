using System;
using FluentValidator;

namespace Store.Domain.StoreContext.Entities
{
  public class OrderItem : Notifiable
  {
    public OrderItem(Product product, decimal quantity)
    {
      Product = product;
      Quantity = quantity;
      Price = product.Price;

      if (product.QuantityOnHand < quantity)
        AddNotification("Quantity", "Falta de quantidade em estoque");
      
      product.DecreaseQuantity(quantity);
    }
    public Product Product { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal Price { get; private set; }
  }
}