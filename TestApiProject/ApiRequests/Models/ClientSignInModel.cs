using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.Models
{
    public class ClientSignInModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}