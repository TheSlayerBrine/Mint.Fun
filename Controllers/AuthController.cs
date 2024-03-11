using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Fun.Clients;
using Mint.Fun.Models;

namespace Mint.Fun.Controllers;
[AllowAnonymous]
[Route("client/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthClient authClient;
    public AuthController(IAuthClient authClient)
    {
        this.authClient = authClient;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        var loginModel = await authClient.Register();
        return Ok(loginModel);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var token = await authClient.Login(loginModel.PublicKey, loginModel.PrivateKey);
        return Ok(token);
    }   
}