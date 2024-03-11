using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Mint.Fun.Clients.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Mint.Fun.Clients;

public class AccountClient : BlockchainClient, IAccountClient
{
    private static string PostDepositUrl = "api/account/DepositAthereum";
    private static string PostWithdrawUrl = "api/account/WithdrawUsd";
    private static string PutUpdateNameUrl = "api/account/UpdateName";
    public AccountClient(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
    {
    }
    public async Task UpdateName(string name)
    {
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ AccessTokens[0]);
        StringContent content = new StringContent(name);
         await Client.PutAsync(PutUpdateNameUrl, content);
    }
    public class Money
    {
        public double Amount { get; set; }
    };
    public async Task DepositBalance(double amount)
    {
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer "+ AccessTokens[0]);

  
        var obj = new Money()
        {
            Amount = amount
        };
        var data = JsonContent.Create(obj, MediaTypeHeaderValue.Parse("application/json"));
        await Client.PostAsync(PostDepositUrl, data);
    }

    public async Task WithdrawBalance(double amount)
    {
        var response = await Client.PostAsync(PostWithdrawUrl, new StringContent(JsonSerializer.Serialize(amount), Encoding.UTF8, "application/json"));
    }
}