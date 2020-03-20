using Newtonsoft.Json;

namespace TestApiProject.ApiRequests.Models
{
    public class ClientProfileModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("facebook_followers")]
        public string FacebookFollowers { get; set; }

        [JsonProperty("instagram_followers")]
        public string InstagramFollowers { get; set; }

        [JsonProperty("has_invite")]
        public bool HasInvite { get; set; }

        [JsonProperty("company_website")]
        public string CompanyWebsite { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("company_description")]
        public string CompanyDescription { get; set; }

        [JsonProperty("referral")]
        public string Referral { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("is_sms_enabled")]
        public string IsSmsEnabled { get; set; }

        [JsonProperty("location_latitude")]
        public string LocationLatitude { get; set; }

        [JsonProperty("location_longitude")]
        public string LocationLongitude { get; set; }

        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        [JsonProperty("location_city_name")]
        public string LocationCityName { get; set; }

        [JsonProperty("location_admin1_code")]
        public string LocationAdmin1Code { get; set; }

        [JsonProperty("location_timezone")]
        public string LocationTimezone { get; set; }

        [JsonProperty("company_address")]
        public string CompanyAddress { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("twitter_followers")]
        public string TwitterFollowers { get; set; }

        [JsonProperty("youtube_followers")]
        public string YoutubeFollowers { get; set; }
    }
}
