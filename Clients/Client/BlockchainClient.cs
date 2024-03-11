using System.Net.Http.Headers;
using System.Text.Json;

namespace Mint.Fun.Clients.Client;

public class BlockchainClient
{
    private readonly IHttpClientFactory httpClientFactory;
    public static string ClientName = "blockchainapi";
    public static HttpClient Client;
   public BlockchainClient(IHttpClientFactory httpClientFactory)
   {
       this.httpClientFactory = httpClientFactory;
       Client = httpClientFactory.CreateClient(ClientName);
        Client.Timeout =  TimeSpan.FromSeconds(600);   
        Client.DefaultRequestHeaders.Add("Bearer", "Bearer <token>");
   }
   protected System.Collections.Generic.List<string> AccessTokens { get; set; } = new()
   {
       "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjB4ODkxQWE4QUFkMWZGQzU5RWUxZEYwRmFBIiwiZXhwIjoxNzAxMTQyMjU0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUxNTciLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUxNTcifQ.B-fQ-v4hqKmAYaYwg4ZD3kCOTFVpVHEoKuaBkIRoNJs"
   };

   protected JsonSerializerOptions JsonSerializerOptions =>
       new()
       {
           PropertyNamingPolicy = JsonNamingPolicy.CamelCase
       };
}