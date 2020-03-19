using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;
using TestApiProject.ApiRequests.NewBookModelsApi.Client;
using TestApiProject.ApiRequests.NewBookModelsApi.Password;

namespace TestApiProject.Tests
{
    [TestFixture]
    class TestLoginByApi
    {
        const string USER_EMAIL = "qweasdasd@qwe.qwea";
        const string PASSWORD = "123qweQWE!";

        [Test]
        public void CheckThatLoginByApiIsPossible()
        {
            var response = new AuthRequests().SendRequestLoginPost(new ClientSignInModel
            {
                Email = USER_EMAIL,
                Password = PASSWORD
            });

            var driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{response.TokenData.Token}');");
            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            Thread.Sleep(3000);
            var result = driver.FindElement(By.CssSelector("div[class^='Avatar'] > div[class^='AvatarClient']")).Displayed;
            driver.Quit();
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckThatIsPossibleChangeClientEmail()
        {
            Context.Token = new AuthRequests().SendRequestLoginPost(new ClientSignInModel { Email = USER_EMAIL, Password = PASSWORD }).TokenData.Token;
            var actualData = new ClientRequest().SendRequestChangeEmail(new ChangeEmailModel { Password = PASSWORD, Email = "test12314wer@we.qwe" });

            Assert.AreEqual("test12314wer@we.qwe", actualData);
        }

        [Test]
        public void CheckThatIsPossibleToUploadPhoto()
        {
            Context.Token = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = USER_EMAIL + DateTime.Now.ToString("ddmmyyyyhhmmss"),
                Password = PASSWORD,
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            }).TokenData.Token;
            new ClientRequest().SendRequestUploadPhoto(@"D:\pngvalid.png");

            var driver = new ChromeDriver();
            IJavaScriptExecutor js = driver;
            driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{Context.Token}');");
            driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            Thread.Sleep(3000);
            var result = driver.FindElement(By.CssSelector("body > nb-app > ng-component > nb-internal-layout > common-layout > section > div > ng-component > nb-profile > common-border > nb-profile-settings > div.row.d-flex.flex-column.align-items-center > nb-profile-settings-view > div > div.profile__info.d-flex.justify-content-center > div > common-avatar > div.avatar__letter.d-flex.justify-content-center.align-items-center")).Displayed;

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

            var token = new PasswordRequests().SendRequestChangePassword(new PasswordModel { NewPassword = "123QWERTYqwe!", OldPassword = PASSWORD });

            Assert.IsNotEmpty(token);
            Assert.That(token.Contains("token"));
        }
    }
}
