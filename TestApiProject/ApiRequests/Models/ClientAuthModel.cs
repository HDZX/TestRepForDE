using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.Models
{
    public class ClientAuthModel
    {
        [JsonProperty("token_data")]
        public AuthTokenModel TokenData { get; set; }
        [JsonProperty("user")]
        public UserModel User { get; set; }
    }
}