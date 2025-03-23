using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IdeaCenterPOM.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;
		protected WebDriverWait _wait;

		public BasePage(IWebDriver driver)
		{
			this._driver = driver;
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
		}

		public virtual string PageUrl { get; }

		public IWebElement LinkLoginPage => _driver.FindElement(By.XPath("//a[contains(text(), 'Login')]"));

		public IWebElement LinkRegisterPage => _driver.FindElement(By.XPath("//a[contains(text(), 'Sign up')]"));

		public IWebElement LinkHomePage => _driver.FindElement(By.XPath("//a[@class='nav-link' and contains(text(), 'Idea Center')]"));

		public void Open()
		{
			_driver.Navigate().GoToUrl(PageUrl);
		}
	}
}

// username: testUser_123
// email: testUser_123@email.com
// password: test1234