using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace TestApiProject
{
    public class RestRequestBuilder
    {
        private readonly RestClient _client;
        private readonly RestRequest _request;

        public RestRequestBuilder(string controller, string methodUri)
        {
            _client = new RestClient(controller + methodUri);
            _request = new RestRequest { Timeout = 300000 };
        }

        public RestRequestBuilder AddMethodType(Method requestMethod)
        {
            _request.Method = requestMethod;

            return this;
        }

        public RestRequestBuilder AddHeader(string key, string value)
        {
            _request.AddHeader(key, value);

            return this;
        }

        public RestRequestBuilder AddJsonBody(object requestBody)
        {
            _request.AddJsonBody(requestBody);

            return this;
        }

        public RestRequestBuilder AddParametersAsJsonRowInRequestBody(object parameters)
        {
            var convertedToJson = JsonConvert.SerializeObject(parameters);

            _request.AddParameter("application/json", convertedToJson, ParameterType.RequestBody);

            return this;
        }

        public RestRequestBuilder AddRequestFormat(DataFormat requestFormat)
        {
            _request.RequestFormat = requestFormat;

            return this;
        }

        public RestRequestBuilder AddCookie(string cookieName, string cookieValue)
        {
            _request.AddCookie(cookieName, cookieValue);

            return this;
        }

        public RestRequestBuilder AddParametersAsRequestBody(object parameters)
        {
            _request.AddParameter("application/json", parameters, ParameterType.RequestBody);

            return this;
        }

        public IRestResponse Execute()
        {
            var response = _client.Execute(_request);

            return response;
        }

        private static Dictionary<string, TValue> ToDictionary<TValue>(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);

            return dictionary;
        }
    }
}