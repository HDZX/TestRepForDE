using OpenQA.Selenium;

namespace SpecflowTestProject.NewBookModelsPOM
{
    public class ClientSignUp
    {
        private readonly IWebDriver _driver;

        public ClientSignUp(IWebDriver driver)
        {
            _driver = driver;
        }

        private static readonly By FinishBtn = By.CssSelector("button[class^=SignupCompany]");

        public bool IsFinishBtnDisplayed()
        {
            return _driver.FindElement(FinishBtn).Displayed;
        }
    }
}
