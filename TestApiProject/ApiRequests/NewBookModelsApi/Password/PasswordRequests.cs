using TestApiProject;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.Url;

public class PasswordRequests
{
    public string SendRequestChangePassword(PasswordModel passwordModel)
    {
        var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Password.Change())
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