using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;

namespace Store.Shared.Handlers
{
  public class FakeEmailService : IEmailService
  {
    public void Send(string to, string from, string subject, string body)
    {
      
    }
  }
}