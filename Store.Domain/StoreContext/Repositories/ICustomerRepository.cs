using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Queries;

namespace Store.Domain.StoreContext.Repositories
{
  public interface ICustomerRepository
  {
    bool CheckDocument(string document);
    bool CheckEmail(string email);
    void Save(Customer customer);
    CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    IEnumerable<ListCustomerQueryResult> Get();
    GetCustomerQueryResult GetById(Guid id);
    IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
  }
}