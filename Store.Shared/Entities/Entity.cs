using System;
using FluentValidator;

namespace Store.Shared.Entities
{
  public abstract class Entity : Notifiable
  {
    public Entity()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
  }
}