using Store.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Store.Tests
{
  [TestClass]
  public class DocumentTests
  {
    private Document _validDocument;
    private Document _invalidDocument;

    public DocumentTests()
    {
      _validDocument = new Document("37434841885");
      _invalidDocument = new Document("12345678910");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
      Assert.AreEqual(false, _invalidDocument.IsValid);
      Assert.AreEqual(1, _invalidDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotNotificationWhenDocumentIsValid()
    {
      var document = new Document("37434841885");
      Assert.AreEqual(true, _validDocument.IsValid);
      Assert.AreEqual(0, _validDocument.Notifications.Count);
    }
  }
}
