using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Enums;

namespace Store.Tests
{
  [TestClass]
  public class OrderTests
  {
    private Customer _validCustomer;

    private Order _validOrder;

    private Product _mouse;

    private Product _keyboard;

    private Product _chair;

    private Product _monitor;

    public OrderTests()
    {
      _validCustomer = createValidCustomer();

      _validOrder = new Order(_validCustomer);

      _mouse = new Product("Dark Core SE", "Mouse Gamer", "mouse.jpg", 590M, 10);
      _keyboard = new Product("Corsair K56", "Teclado Gamer", "teclado.jpg", 280M, 10);
      _chair = new Product("Cadeira Assunção DFR34", "Cadeira de escritório", "cadeira.jpg", 180M, 5);
      _monitor = new Product("LG 25' Ultrawide", "Mouse Gamer", "monitor.jpg", 900M, 3);
    }

    public Customer createValidCustomer()
    {
      var name = new Name("Carol", "Vasconcelos");
      var document = new Document("37434841885");
      var email = new Email("cvsouza04@gmail.com");
      var phone = "11 952023724";

      return new Customer(name, document, email, phone);
    }

    [TestMethod]
    public void ShouldCreateOrderWhenValid()
    {
      Assert.AreEqual(true, _validOrder.IsValid);
    }

    [TestMethod]
    public void StatusShouldBeCreatedWhenOrderCreated()
    {
      Assert.AreEqual(EOrderStatus.Created, _validOrder.Status);
    }

    [TestMethod]
    public void ShouldReturnTwoWhenAddedTwoValidItems()
    {
      _validOrder.AddItem(_monitor, 3);
      _validOrder.AddItem(_mouse, 5);
      Assert.AreEqual(2, _validOrder.Items.Count);
    }

    [TestMethod]
    public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
    {
      _validOrder.AddItem(_mouse, 5);
      Assert.AreEqual(_mouse.QuantityOnHand, 5);
    }

    [TestMethod]
    public void ShouldReturnANumberWhenOrderPlaced()
    {
      _validOrder.Place();
      Assert.AreNotEqual("", _validOrder.Number);
    }

    [TestMethod]
    public void ShouldReturnPaidWhenOrderPaid()
    {
      _validOrder.Pay();
      Assert.AreEqual(EOrderStatus.Paid, _validOrder.Status);
    }

    [TestMethod]
    public void ShouldReturnTwoWhenPurchasedTenProducts()
    {
      for (var i = 0; i <= 10; i++)
        _validOrder.AddItem(_mouse, 1);

      _validOrder.Ship();

      Assert.AreEqual(2, _validOrder.Deliveries.Count);
    }

    [TestMethod]
    public void StatusShouldBeCanceledWhenOrderCanceled()
    {
      _validOrder.Cancel();
      Assert.AreEqual(EOrderStatus.Canceled, _validOrder.Status);
    }

    [TestMethod]
    public void ShouldCancelShippingWhenOrderCanceled()
    {
      for (var i = 0; i <= 10; i++)
        _validOrder.AddItem(_mouse, 1);

      _validOrder.Ship();

      _validOrder.Cancel();

      foreach (var delivery in _validOrder.Deliveries)
        Assert.AreEqual(EDeliveryStatus.Canceled, delivery.Status);
    }
  }
}
