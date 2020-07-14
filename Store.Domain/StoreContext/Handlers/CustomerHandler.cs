using System;
using FluentValidator;
using Store.Shared.Commands;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.CustomerCommands.Outputs;

namespace Store.Domain.StoreContext.Handlers
{
  public class CustomerHandler :
          Notifiable,
          ICommandHandler<CreateCustomerCommand>,
          ICommandHandler<AddAddressCommand>

  {
    public ICommandResult Handle(CreateCustomerCommand command)
    {
      // VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);

      // Entity
      var customer = new Customer(name, document, email, command.Phone);

      // Validating
      AddNotifications(name.Notifications);
      AddNotifications(document.Notifications);
      AddNotifications(email.Notifications);
      AddNotifications(customer.Notifications);
      
      return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      
    }
  }
}