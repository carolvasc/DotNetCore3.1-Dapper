using FluentValidator;
using Store.Shared.Commands;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.CustomerCommands.Inputs
{
  public class CreateCustomerCommand : Notifiable, ICommand
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    // Fail Fast Validation -> Realiza as mesmas validações das entidades e VOs para evitar fazer requests desnecessários ao banco.
    // Se por algum acaso esses testes abaixo falhem, a validação continua sendo feita dentro das entidades e VOs, logo não tem problema.
    public bool Valid()
    {
      AddNotifications(new ValidationContract()
        .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres.")
        .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres.")
        .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres.")
        .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres.")
        .IsEmail(Email, "Address", "O E-mail está inválido.")
        .HasLen(Document, 11, "Document", "CPF inválido")
      );
      return IsValid;
    }
  }
}