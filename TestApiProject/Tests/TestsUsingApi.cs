using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestApiProject.ApiRequests.Models;
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


        [Test]
        public void CheckThatLoginUsingTokenFromApiInBrowserIsPossible()
        {
            var leadRegistrationData = new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            };

            var authRequests = new AuthRequests();
            var leadRegistrationResponseData = authRequests.SendRequestSignUpPost(leadRegistrationData);
            Context.Token = leadRegistrationResponseData.TokenData.Token;

            var driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{Context.Token}');");
            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            Thread.Sleep(3000);
            var result = driver.FindElement(By.CssSelector("div[class^='Avatar'] > div[class^='AvatarClient']")).Displayed;
            driver.Quit();
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckThatIsPossibleToChangePasswordByApi()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            }).TokenData.Token;

            var token = new PasswordRequests().SendRequestChangePassword(
                new PasswordModel
                {
                    NewPassword = "123QWERTYqwe!",
                    OldPassword = PASSWORD
                });

            Assert.That(token.Contains("token"));
        }
    }
}