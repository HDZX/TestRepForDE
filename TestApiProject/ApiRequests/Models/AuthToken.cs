using Newtonsoft.Json;
using System;

namespace TestApiProject.ApiRequests.Models
{
    public class AuthTokenModel
    {
        public string Token { get; set; }
        [JsonProperty("token_refresh_expires")]
        public DateTime TokenRefreshExpires { get; set; }
        [JsonProperty("firebase_token")]
        public string FirebaseToken { get; set; }
        [JsonProperty("firebase_token_expires")]
        public DateTime FirebaseTokenExpires { get; set; }
    }
}