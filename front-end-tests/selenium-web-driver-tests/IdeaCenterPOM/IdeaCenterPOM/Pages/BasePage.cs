using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace IdeaCenterPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;

		protected WebDriverWait _wait;

		protected Actions actions;

		public BasePage(IWebDriver driver)
		{
			_driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			actions = new Actions(driver);
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