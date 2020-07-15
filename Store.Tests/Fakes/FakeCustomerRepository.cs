using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;

namespace Store.Shared.Handlers
{
  public class FakeCustomerRepository : ICustomerRepository
  {
    public bool CheckDocument(string document)
    {
      return false;
    }

    public bool CheckEmail(string email)
    {
      return false;
    }

    public void Save(Customer customer)
    {

    }
  }
}