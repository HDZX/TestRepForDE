namespace TestApiProject.ApiRequests.Url
{
    public class NewBookModelsUrl
    {
        public static string GetBaseUrl(string apiVersion = null)
        {
            var baseUrl = "https://api.newbookmodels.com/api/";

            switch (apiVersion)
            {
                case "1":
                    baseUrl += "v1/";
                    break;
            }

            return baseUrl;
        }

        public static class Auth
        {
            private static string _controller = "auth";

            public static string SingIn()
            {
                return _controller + "/signin/";
            }

            public static string Client_SignUp()
            {
                return _controller + "/client/signup/";
            }
        }

        public static class Password
        {
            private static string _controller = "password";

            public static string Change()
            {
                return _controller + "/change/";
            }
        }
    }
}