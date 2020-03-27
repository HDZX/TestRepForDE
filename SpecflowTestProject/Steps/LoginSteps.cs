using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestProject.NewBookModelsPOM;
using TechTalk.SpecFlow;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.NewBookModelsApi.Auth;

namespace SpecflowTestProject
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"Client is created")]
        public void GivenClientIsCreated()
        {
            var response = new AuthRequests().SendRequestSignUpPost(new ClientSignUpModel
            {
                Email = "qweasd" + DateTime.Now.ToString("hhmmss") + "asd@gmail.com",
                Password = "123qweQWE!",
                FirstName = "sdfsadfsf",
                LastName = "asdadasdsad",
                PhoneNumber = "1231231231"
            });

            ScenarioContext.Current["client"] = response.User;
            ScenarioContext.Current["token"] = response.TokenData.Token;
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            new SignInPage(_driver).SignInPageIsOpened();
        }

        [When(@"I input email of created client in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var clientEmail = ((ClientAuthModel)ScenarioContext.Current["client"]).User.Email;
            new SignInPage(_driver).FillEmailField(clientEmail);
        }

        [When(@"I input password of created client in email field")]
        public void WhenIInputPasswordOfCreatedClientInEmailField()
        {
            new SignInPage(_driver).FillPasswordField("123qweQWE!");
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            new SignInPage(_driver).ClickLogInBtn();
        }

        [Then(@"I successfully logged in NewBookModels as created client")]
        public void ThenISuccessfullyLoggedInNewBookModelsAsCreatedClient()
        {
            Thread.Sleep(5000);
            Assert.True(new ClientSignUpPage(_driver).IsFinishBtnDisplayed());
        }
    }
}
