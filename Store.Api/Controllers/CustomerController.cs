using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.CustomerCommands.Outputs;

namespace Store.Api.Controllers
{
  public class CustomerController : Controller
  {
    private readonly ICustomerRepository _repository;
    private readonly CustomerHandler _handler;
    public CustomerController(ICustomerRepository repository, CustomerHandler handler)
    {
      _repository = repository;
      _handler = handler;
    }

    [HttpGet]
    [Route("customers")]
    public IEnumerable<ListCustomerQueryResult> Get()
    {
      return _repository.Get();
    }

    [HttpGet]
    [Route("customers/{id:int}")]
    public GetCustomerQueryResult GetById(Guid id)
    {
      return _repository.GetById(id);
    }

    [HttpGet]
    [Route("customers/{id:int}/orders")]
    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      return _repository.GetOrders(id);
    }

    [HttpPost]
    [Route("customers/{id:int}")]
    public object Post([FromBody] CreateCustomerCommand command)
    {
      var result = (CreateCustomerCommandResult)_handler.Handle(command);
      if (_handler.Invalid)
        return BadRequest(_handler.Notifications);

      return result;
    }

    [HttpPut]
    [Route("customers/{id:int}")]
    public Customer Put([FromBody] CreateCustomerCommand command)
    {
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);
      var customer = new Customer(name, document, email, command.Phone);

      return customer;
    }

    [HttpDelete]
    [Route("customers/{id:int}")]
    public object Delete(Guid id)
    {
      return new { message = "Cliente removido com sucesso!" };
    }
  }
}