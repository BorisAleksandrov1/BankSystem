using System.Dynamic;
using Newtonsoft.Json;

public class UserDTO
{
    [JsonProperty("Password")]
    public string Password { get; set; }

    [JsonProperty("_userName")]
    public string UserName { get; set; }

    [JsonProperty("_email")]
    public string Email { get; set; }

    [JsonProperty("_balance")]
    public decimal Balance { get; set; }

    [JsonProperty("_accounts")]
    public Dictionary<string, bankAccount> Accounts { get; set;}

    [JsonProperty("_currentAccount")]

    public bankAccount currentAccount;
}
