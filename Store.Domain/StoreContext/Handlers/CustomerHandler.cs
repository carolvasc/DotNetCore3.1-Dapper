using System;
using FluentValidator;
using Store.Shared.Commands;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.CustomerCommands.Inputs;
using Store.Domain.StoreContext.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;

namespace Store.Domain.StoreContext.Handlers
{
  public class CustomerHandler :
          Notifiable,
          ICommandHandler<CreateCustomerCommand>,
          ICommandHandler<AddAddressCommand>

  {
    private readonly ICustomerRepository _repository;
    private readonly IEmailService _emailService;
    public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
    {
      _repository = repository;
      _emailService = emailService;
    }

    public ICommandResult Handle(CreateCustomerCommand command)
    {
      // Validating CPF...
      if (_repository.CheckDocument(command.Document))
        AddNotification("Document", "Este CPF já está em uso");

      // Validating email...
      if (_repository.CheckEmail(command.Email))
        AddNotification("Email", "Este E-mail já está em uso");

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

      if (Invalid)
        return null;

      _repository.Save(customer);

      _emailService.Send(email.Address, "test@gmail.com", "Bem vindo", "Seja bem vindo");

      return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}