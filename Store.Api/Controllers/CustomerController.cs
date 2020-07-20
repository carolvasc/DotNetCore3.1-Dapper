using System;
using System.Collections.Generic;
using Store.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.CustomerCommands.Inputs;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Fernanda", "Montenegro");
            var document = new Document("46718115533");
            var email = new Email("teste@gmail.com");
            var customer = new Customer(name, document, email, "5511974857485");

            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id:int}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Fernanda", "Montenegro");
            var document = new Document("46718115533");
            var email = new Email("teste@gmail.com");
            var customer = new Customer(name, document, email, "5511974857485");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id:int}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("César", "Figueiredo");
            var document = new Document("66162305031");
            var email = new Email("cezinha@gmail.com");
            var customer = new Customer(name, document, email, "5511974857485");

            var order = new Order(customer);
            var mouse = new Product("Dark Core SE", "Mouse Gamer", "mouse.jpg", 590M, 10);
            var monitor = new Product("LG 25' Ultrawide", "Mouse Gamer", "monitor.jpg", 900M, 3);

            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
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