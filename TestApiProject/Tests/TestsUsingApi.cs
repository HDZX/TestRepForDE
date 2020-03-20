using NUnit.Framework;
using System;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;

namespace TestApiProject.Tests
{
    [TestFixture]
    class TestsUsingApi
    {
        const string USER_EMAIL = "qweasdasd@qwe.qwea";
        const string PASSWORD = "123qweQWE!";

        [Test]
        public void CheckThatIsPossibleToCreateNewUserUsingApi()
        {
            var expectedEmail = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss");
            var client = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = expectedEmail,
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });

            Assert.Multiple(() =>
            {
                Assert.That(client.User.Id != null && client.User.Id != string.Empty);
                Assert.IsTrue(client.User.Email == expectedEmail);
            });
        }
    }
}