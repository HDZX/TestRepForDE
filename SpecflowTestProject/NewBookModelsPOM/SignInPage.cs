using OpenQA.Selenium;

namespace SpecflowTestProject.NewBookModelsPOM
{
    public class SignInPage
    {
        private readonly IWebDriver _driver;

        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private static readonly By EmailField = By.CssSelector("input[type=email]");
        private static readonly By PasswordField = By.CssSelector("input[type=password]");
        private static readonly By LogInBtn = By.CssSelector("button[class^=SignInForm]");

        public void FillEmailField(string email)
        {
            _driver.FindElement(EmailField).SendKeys(email);
        }

        public void FillPasswordField(string password)
        {
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void ClickLogInBtn()
        {
            _driver.FindElement(LogInBtn).Click();
        }

        public void SignInPageIsOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
        }
    }
}