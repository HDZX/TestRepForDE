using Newtonsoft.Json;
using RestSharp;
using TestApiProject.ApiRequests.Url;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Client
{
    public class ClientRequest
    {
        public string SendRequestChangeEmail(ChangeEmailModel changeEmailModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUri.GetBaseUrl("1"), "client/change_email/")
                .AddHeader("authorization", Context.Token)
                .AddHeader("cache-control", "no-cache")
                .AddHeader("content-type", "application/json")
                .AddParametersAsJsonRowInRequestBody(changeEmailModel)
                .AddMethodType(Method.POST)
                .AddRequestFormat(DataFormat.Json)
                .Execute();

            return JsonConvert.DeserializeObject<ChangeEmailModel>(response.Content).Email;

        }

        public IRestResponse SendRequestUploadPhoto(string filePath)
        {
            var res = new RestRequestBuilder(NewBookModelsUri.GetBaseUrl(), "images/upload/")
                 .AddHeader("authorization", Context.Token)
                 .AddHeader("cache-control", "no-cache")
                 .AddFile( filePath)
                 .AddMethodType(Method.POST)
                 .AddRequestFormat(DataFormat.Json)
                 .Execute();
            return res;
        }
    }

    public class ChangeEmailModel
    {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}