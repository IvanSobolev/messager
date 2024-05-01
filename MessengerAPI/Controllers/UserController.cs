using Microsoft.AspNetCore.Mvc;

[Route("/user")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("/register")]
    public Token Register([FromBody] User user)
    {
        return _userManager.Register(user);
    }

    [HttpPost("/login")]
    public Token Login([FromBody] string login, [FromBody] string password)
    {
        return _userManager.LogIn(login,password);
    }

    [HttpDelete("/logout")]
    public IActionResult Logout([FromBody] string token)
    {
        _userManager.Logout(token);
        return Ok("Token deleted");
    }
}