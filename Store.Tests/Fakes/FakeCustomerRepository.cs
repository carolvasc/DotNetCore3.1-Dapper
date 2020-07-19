using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;
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

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      throw new System.NotImplementedException();
    }

    public void Save(Customer customer)
    {

    }
  }
}