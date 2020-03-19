using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.Models
{
    public class ChangeEmailModel
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}