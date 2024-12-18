using Newtonsoft.Json;

public class UserDTO
{
    [JsonProperty("Password")]
    public string Password { get; set; }

    [JsonProperty("UserName")]
    public string UserName { get; set; }
}
