using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Mint.Fun.Clients.Client;
using Mint.Fun.Models;

namespace Mint.Fun.Clients;

public class AuthClient : BlockchainClient,IAuthClient
{
    private static string PostRegisterUrl = "api/auth/register";
    private static string PostLoginUrl = "api/auth/login";
    
    public AuthClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }
    
    public async Task<AccountModel> Register()
    {
        var response = await Client.PostAsync(PostRegisterUrl, null);
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<AccountModel>(content, JsonSerializerOptions);
        return result;
    }
    
    public async Task<LoginResponse> Login(string publicKey, string privateKey)
    {
        var loginModel = new LoginModel()
        {
            PublicKey = publicKey, PrivateKey = privateKey
        };
        var response = await Client.PostAsync(PostLoginUrl, new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<LoginResponse>(content, JsonSerializerOptions);
        AccessTokens.Add(result.Token);
        return result;
    }
}