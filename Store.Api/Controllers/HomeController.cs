using Microsoft.AspNetCore.Mvc;

namespace Store.Api.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    [Route("rota/01")]
    public object Get()
    {
      return new { version = "Version 0.0.1" };
    }

    [HttpPost]
    [Route("rota/01")]
    public object Post()
    {
      return new { version = "Version 0.0.1" };
    }

    [HttpPut]
    [Route("rota/01")]
    public object Put()
    {
      return new { version = "Version 0.0.1" };
    }

    [HttpDelete]
    [Route("rota/01")]
    public object Delete()
    {
      return new { version = "Version 0.0.1" };
    }
  }
}