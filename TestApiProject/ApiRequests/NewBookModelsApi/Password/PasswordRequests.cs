using TestApiProject.ApiRequests.Url;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Password
{
    public class PasswordRequests
    {
        public string SendRequestChangePassword(PasswordModel passwordModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUri.GetBaseUrl("1"),
                NewBookModelsUri.Password.Change())
                .AddParametersAsJsonRowInRequestBody(passwordModel)
                .AddMethodType(RestSharp.Method.POST)
                .AddRequestFormat(RestSharp.DataFormat.Json)
                .AddHeader("authorization", Context.Token)
                .AddHeader("cache-control", "no-cache")
                .AddHeader("content-type", "application/json")
                .Execute();

            return response.Content;
        }
    }
}