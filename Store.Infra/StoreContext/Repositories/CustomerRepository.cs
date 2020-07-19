using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Queries;
using Store.Infra.DataContexts;
using Dapper;

namespace Store.Infra.StoreContext.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
      _context = context;
    }

    public bool CheckDocument(string document)
    {
      return _context
              .Connection
              .Query<bool>(
                "spCheckDocument",
                new { Document = document },
                commandType: CommandType.StoredProcedure)
              .FirstOrDefault();

      // Exemplo para criar query na mão
      // return _context
      //         .Connection
      //         .Query<bool>(
      //           "select * from customer where document=@document",
      //           new { Document = document })
      //         .FirstOrDefault();
    }

    public bool CheckEmail(string email)
    {
      return _context
            .Connection
            .Query<bool>(
              "spCheckEmail",
              new { Email = email },
              commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      return _context
            .Connection
            .Query<CustomerOrdersCountResult>(
              "spGetCustomerOrdersCount",
              new { Document = document },
              commandType: CommandType.StoredProcedure)
            .FirstOrDefault();
    }

    public void Save(Customer customer)
    {
      _context
      .Connection
      .Execute(
        "spCreateCustomer",
          new
          {
            Id = customer.Id,
            FirstName = customer.Name.FirstName,
            LastName = customer.Name.LastName,
            Document = customer.Document.Number,
            Email = customer.Email.Address,
            Phone = customer.Phone,
          },
          commandType: CommandType.StoredProcedure);

      SaveAddress(customer);
    }

    public void SaveAddress(Customer customer)
    {
      foreach (var address in customer.Addresses)
      {
        _context
        .Connection
        .Execute(
          "spCreateAddress",
          new
          {
            Id = address.Id,
            Customer = customer.Id,
            Number = address.Number,
            Complement = address.Complement,
            District = address.District,
            City = address.City,
            State = address.State,
            Country = address.Country,
            ZipCode = address.ZipCode,
            Type = address.Type,
          },
          commandType: CommandType.StoredProcedure);
      }
    }
  }
}