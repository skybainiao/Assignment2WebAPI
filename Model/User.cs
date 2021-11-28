using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoginExample.Models {
public class User {
    
    [JsonPropertyName("UserName"), Key]
    public string UserName { get; set; }
    [JsonPropertyName("Password")]
    public string Password { get; set; }


    public User(string userName,string password)
    {
       UserName = userName;
       Password = password;
    }
}
}