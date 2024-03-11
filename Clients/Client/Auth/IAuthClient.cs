using System.Text.Json;
using Mint.Fun.Models;

namespace Mint.Fun.Clients;

public interface IAuthClient
{
    JsonSerializerOptions jsonSerializerOptions { get{ return new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }; }}
    Task<AccountModel> Register();
    Task<LoginResponse> Login(string publicKey, string privateKey);
}