using Newtonsoft.Json;
using System;

namespace TestApiProject.ApiRequests.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        [JsonProperty("payment_method_connected")]
        public string PaymentMethodConnected { get; set; }

        [JsonProperty("is_staff")]
        public string IsStaff { get; set; }

        [JsonProperty("email_verified")]
        public string EmailVerified { get; set; }

        [JsonProperty("client_profile")]
        public ClientProfileModel ClientProfile { get; set; }

        [JsonProperty("has_password")]
        public string HasPassword { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }
}
