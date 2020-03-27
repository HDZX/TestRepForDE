using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowTestProject.NewBookModelsPOM;
using TechTalk.SpecFlow;

namespace SpecflowTestProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver = (IWebDriver)ScenarioContext.Current["driver"];

        [Given(@"Successfully logged into NewBookModels through Api")]
        public void GivenSuccessfullyLoggedIntoNewBookModelsThroughApi()
        {
            var js = (IJavaScriptExecutor)_driver;
            _driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            js.ExecuteScript($"localStorage.setItem('access_token','{ScenarioContext.Current["token"]}');");
        }

        [Given(@"Profile page is opened")]
        public void GivenProfilePageIsOpened()
        {
            new ProfilePage(_driver).EditProfilePageIsOpened();
        }

        [When(@"I click on pencil button")]
        public void WhenIClickOnPencilButton()
        {
            new ProfilePage(_driver).ClickPencilBtn();
        }

        [When(@"I upload client's photo")]
        public void WhenIUploadClientSPhoto()
        {
            new ProfilePage(_driver).UploadPhoto();
        }

        [When(@"I input company name '(.*)' in company name field")]
        public void WhenIInputCompanyNameInCompanyNameField(string p0)
        {
            new ProfilePage(_driver).FillCompanyNameField(p0);
        }

        [When(@"I input company url '(.*)' in company url field")]
        public void WhenIInputCompanyUrlInCompanyUrlField(string p0)
        {
            new ProfilePage(_driver).FillCompanyUrlField(p0);
        }

        [When(@"I input '(.*)' in description field")]
        public void WhenIInputInDescriptionField(string p0)
        {
            new ProfilePage(_driver).FillDescriptionField(p0);
        }

        [When(@"I click save changes button")]
        public void WhenIClickSaveChangesButton()
        {
            new ProfilePage(_driver).ClickSaveChangesBtn();
        }

        [Then(@"Client's avatar is successfully changed")]
        public void ThenClientSAvatarIsSuccessfullyChanged()
        {
            Assert.True(new ProfilePage(_driver).IsClientAvatarDisplayed());
        }
    }
}
