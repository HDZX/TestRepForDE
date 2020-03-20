using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.Models
{
    public class PasswordModel
    {
        [JsonProperty("old_password")]
        public string OldPassword { get; set; }
        [JsonProperty("new_password")]
        public string NewPassword { get; set; }
    }
}