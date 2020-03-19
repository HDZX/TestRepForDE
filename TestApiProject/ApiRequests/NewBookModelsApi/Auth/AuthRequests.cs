using Newtonsoft.Json;
using RestSharp;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.Url;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Auth
{
    public class AuthRequests
    {
        public ClientAuthModel SendRequestLoginPost(ClientSignInModel clientSignUpModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Auth.SingIn())
                .AddParametersAsJsonRowInRequestBody(clientSignUpModel)
                .AddMethodType(Method.POST)
                .AddHeader("content-type", "application/json")
                .AddRequestFormat(DataFormat.Json)
                .Execute();

            return JsonConvert.DeserializeObject<ClientAuthModel>(response.Content);
        }

        public ClientAuthModel SendRequestSignUpPost(ClientSignUpModel clientSignUpModel)
        {
            var resp = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Auth.Client_SignUp())
                .AddParametersAsJsonRowInRequestBody(clientSignUpModel)
                .AddMethodType(Method.POST)
                .AddHeader("content-type", "application/json")
                .AddRequestFormat(DataFormat.Json)
                .Execute();

            return JsonConvert.DeserializeObject<ClientAuthModel>(resp.Content);

        }
    }
}