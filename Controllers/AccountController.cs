using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Mint.Fun.Clients;

namespace Mint.Fun.Controllers;
[Route("client/account")]
[ApiController]
public class AccountController
{
    private readonly IAccountClient accountClient;
    public AccountController(IAccountClient accountClient)
    {
        this.accountClient = accountClient;
    }
    [HttpPut("name")]
    public async Task UpdateName([FromQuery]string name)
    {
       await accountClient.UpdateName(name);
    }
    [HttpPost("deposit")]
    public async Task DepositBalance([FromQuery]double amount)
    { 
       await accountClient.DepositBalance(amount);
    }
    [HttpPost("withdraw")]
    public async Task WithdrawBalance([FromQuery]double amount)
    {
       await accountClient.WithdrawBalance(amount);
    }
}