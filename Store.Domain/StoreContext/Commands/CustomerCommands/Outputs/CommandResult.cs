using System;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.CustomerCommands.Outputs
{
  public class CommandResult : ICommandResult
  {
    public CommandResult(bool success, string message, object data)
    {
      Success = success;
      Message = message;
      Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
  }
}