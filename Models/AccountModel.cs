namespace Mint.Fun.Models;

public class AccountModel
{
    public string PublicKey { get; set; }
    public string? Nickname { get; set; }
    public string PrivateKey { get; set; }
    public double Balance { get; set; }
}