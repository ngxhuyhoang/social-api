using Microsoft.AspNetCore.Mvc;

namespace social_api.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
  [HttpPost("login")]
  public IActionResult Login() => Ok("Hello World");

  [HttpPost("register")]
  public IActionResult Register() => Ok("Hello World");
}