using Microsoft.AspNetCore.Mvc;

namespace Mint.Fun.Clients;

public interface IAccountClient
{
    public Task DepositBalance(double amount);
    public Task UpdateName(string name);
    public Task WithdrawBalance(double amount);
}