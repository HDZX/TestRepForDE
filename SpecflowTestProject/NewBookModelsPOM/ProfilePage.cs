using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SpecflowTestProject.NewBookModelsPOM
{
    public class ProfilePage
    {
        private readonly IWebDriver _driver;

        public ProfilePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private static readonly By CompanyNameField = By.CssSelector("input[placeholder='Enter company name']");
        private static readonly By PencilBtn = By.CssSelector("body > nb-app > ng-component > nb-internal-layout > common-layout > section > div > ng-component > nb-profile > common-border > nb-profile-settings > div.row.d-flex.justify-content-between.align-items-center.px-3 > div > div");
        private static readonly By CompanyUrlField = By.CssSelector("input[placeholder='Enter company website URL']");
        private static readonly By DescriptionField = By.CssSelector("textarea[placeholder='Enter company description']");
        private static readonly By SaveChangesBtn = By.CssSelector("body > nb-app > ng-component > nb-internal-layout > common-layout > section > div > ng-component > nb-profile > common-border > nb-profile-settings > nb-profile-settings-edit-container > nb-profile-settings-edit > form > div > div.container-fluid.p-0.mt-5 > div > div.col-24.py-4.pl-3 > common-button-deprecated > button");
        private static readonly By DropArea = By.CssSelector("body > nb-app > ng-component > nb-internal-layout > common-layout > section > div > ng-component > nb-profile > common-border > nb-profile-settings > nb-profile-settings-edit-container > nb-profile-settings-edit > form > div > div.profile__info.d-flex.justify-content-center");
        private static readonly By UploadedClientAvatar = By.CssSelector(".col-md-12 .avatar__image");

        public void UploadPhoto()
        {
            const string jsDropFile = "for(var b=arguments[0],k=arguments[1],l=arguments[2],c=b.ownerDocument,m=0;;){var e=b.getBoundingClientRect(),g=e.left+(k||e.width/2),h=e.top+(l||e.height/2),f=c.elementFromPoint(g,h);if(f&&b.contains(f))break;if(1<++m)throw b=Error('Element not interractable'),b.code=15,b;b.scrollIntoView({behavior:'instant',block:'center',inline:'center'})}var a=c.createElement('INPUT');a.setAttribute('type','file');a.setAttribute('style','position:fixed;z-index:2147483647;left:0;top:0;');a.onchange=function(){var b={effectAllowed:'all',dropEffect:'none',types:['Files'],files:this.files,setData:function(){},getData:function(){},clearData:function(){},setDragImage:function(){}};window.DataTransferItemList&&(b.items=Object.setPrototypeOf([Object.setPrototypeOf({kind:'file',type:this.files[0].type,file:this.files[0],getAsFile:function(){return this.file},getAsString:function(b){var a=new FileReader;a.onload=function(a){b(a.target.result)};a.readAsText(this.file)}},DataTransferItem.prototype)],DataTransferItemList.prototype));Object.setPrototypeOf(b,DataTransfer.prototype);['dragenter','dragover','drop'].forEach(function(a){var d=c.createEvent('DragEvent');d.initMouseEvent(a,!0,!0,c.defaultView,0,0,0,g,h,!1,!1,!1,!1,0,null);Object.setPrototypeOf(d,null);d.dataTransfer=b;Object.setPrototypeOf(d,DragEvent.prototype);f.dispatchEvent(d)});a.parentElement.removeChild(a)};c.documentElement.appendChild(a);a.getBoundingClientRect();return a;";

            var target = _driver.FindElement(DropArea);
            var driver = ((RemoteWebElement)target).WrappedDriver;
            var js = (IJavaScriptExecutor)driver;
            var input = (IWebElement)js.ExecuteScript(jsDropFile, target, 0, 0);

            input.SendKeys(@"C:\Users\User\Desktop\download.jpg");
        }

        public void ClickPencilBtn()
        {
            _driver.FindElement(PencilBtn).Click();
        }

        public void FillCompanyNameField(string companyName)
        {
            _driver.FindElement(CompanyNameField).SendKeys(companyName);
        }

        public bool IsClientAvatarDisplayed()
        {
            return _driver.FindElement(UploadedClientAvatar).Displayed;
        }

        public void FillCompanyUrlField(string companyUrl)
        {
            _driver.FindElement(CompanyUrlField).SendKeys(companyUrl);
        }

        public void FillDescriptionField(string description)
        {
            _driver.FindElement(DescriptionField).SendKeys(description);
        }

        public void ClickSaveChangesBtn()
        {
            _driver.FindElement(SaveChangesBtn).Click();
        }

        public void EditProfilePageIsOpened()
        {
            _driver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/profile/edit");
        }
    }
}
