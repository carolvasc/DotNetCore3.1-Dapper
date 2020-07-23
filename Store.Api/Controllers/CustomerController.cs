using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Queries;
using Store.Domain.StoreContext.Repositories;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
				private readonly ICustomerRepository _repository;
				public CustomerController(ICustomerRepository repository)
				{
						_repository = repository;
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
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
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