using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IdeaCenterPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;
		protected WebDriverWait _wait;

		public BasePage(IWebDriver driver)
		{
			this._driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		public virtual string PageUrl { get; set; } = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83";

		public void OpenPage()
		{
			_driver.Navigate().GoToUrl(PageUrl);
		}

		public bool IsPageOpened()
		{
			return _wait.Until(ExpectedConditions.UrlToBe(PageUrl));
		}
	}
}

// username: testUser_123
// email: testUser_123@email.com
// password: test1234