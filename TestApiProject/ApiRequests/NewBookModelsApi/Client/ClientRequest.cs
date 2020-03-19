using Newtonsoft.Json;
using RestSharp;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.Url;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Client
{
    public class ClientRequest
    {
        public string SendRequestChangeEmail(ChangeEmailModel changeEmailModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), "client/change_email/")
                .AddHeader("authorization", Context.Token)
                .AddHeader("cache-control", "no-cache")
                .AddHeader("content-type", "application/json")
                .AddParametersAsJsonRowInRequestBody(changeEmailModel)
                .AddMethodType(Method.POST)
                .AddRequestFormat(DataFormat.Json)
                .Execute();

            return JsonConvert.DeserializeObject<ChangeEmailModel>(response.Content).Email;

        }
    }
}