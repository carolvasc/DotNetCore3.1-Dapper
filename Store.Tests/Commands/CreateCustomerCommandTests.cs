using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.CustomerCommands.Inputs;

namespace Store.Tests
{
  [TestClass]
  public class CreateCustomerCommandTests
  {
    [TestMethod]
    public void ShouldValidateWhenCommandIsValid()
    {
      var command = new CreateCustomerCommand();

      command.FirstName = "Henrique";
      command.LastName = "Cardoso";
      command.Document = "20711026068";
      command.Email = "hcardoso@gmail.com";
      command.Phone = "11956895689";

      Assert.AreEqual(true, command.Valid());
    }
  }
}
