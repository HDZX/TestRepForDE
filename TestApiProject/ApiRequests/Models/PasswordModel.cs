using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Password
{
    public class PasswordModel
    {
        [JsonProperty("old_password")]
        public string OldPassword { get; set; }

        [JsonProperty("new_password")]
        public string NewPassword { get; set; }
    }
}