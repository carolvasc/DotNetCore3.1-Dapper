using System;
using System.Linq;
using System.Collections.Generic;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Entities;

namespace Store.Domain.StoreContext.Entities
{
  public class Customer : Entity
  {
    private readonly IList<Address> _addresses;
    public Customer(Name name, Document document, Email email, string phone)
    {
      Name = name;
      Document = document;
      Email = email;
      Phone = phone;
      _addresses = new List<Address>();
    }

    public Name Name { get; set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public string Phone { get; private set; }
    // public IReadOnlyCollection<Address> Addresses { get { return _addresses.ToArray(); } }
    public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

    public void AddAddress(Address address)
    {
      // Validar o endereço
      // Adicionar o endereço
      _addresses.Add(address);
    }

    public override string ToString()
    {
      return Name.ToString();
    }
  }
}