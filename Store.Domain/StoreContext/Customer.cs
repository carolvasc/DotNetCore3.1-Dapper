using System;

namespace Store.Domain.StoreContext
{
  public interface IPerson {

  }
  
  public abstract class Person
  {
    // Proporties 
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Salary { get; set; }
  }

  public sealed class Customer : Person
  {
    // Methods
    public void Register()
    {

    }

    // Events
    public void AfterRegister()
    {

    }
  }
}