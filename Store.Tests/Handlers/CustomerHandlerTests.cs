using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Handlers;

namespace Store.Shared.Handlers
{
  [TestClass]
  public class CustomerHandlerTests
  {
    [TestMethod]
    public void ShouldRegisterCustomerWhenCommandIsValid()
    {
      var command = new CreateCustomerCommand();
      command.FirstName = "Fernanda";
      command.LastName = "Martins";
      command.Document = "28659170377";
      command.Email = "fernandamartins@gmail.com";
      command.Phone = "11985749685";

      Assert.AreEqual(true, command.Valid());

      var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
      var result = handler.Handle(command);

      Assert.AreNotEqual(null, result);
      Assert.AreEqual(true, handler.IsValid);
    }
  }
}