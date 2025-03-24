using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class HomePage : BasePage
	{
		public HomePage(IWebDriver driver) : base(driver)
		{
		}

		public override string PageUrl => base.PageUrl + "/";

		public IWebElement LinkLoginPage => _driver.FindElement(By.XPath("//a[contains(text(), 'Login')]"));

		public IWebElement LinkRegisterPage => _driver.FindElement(By.XPath("//a[contains(text(), 'Sign up')]"));

		public IWebElement LinkHomePage => _driver.FindElement(By.XPath("//a[@class='nav-link' and contains(text(), 'Idea Center')]"));

		public IWebElement MyProfileLink => _driver.FindElement(By.XPath("//a[contains(text(), 'My Profile')]"));

		public IWebElement MyIdeasLink => _driver.FindElement(By.XPath("//a[contains(text(), 'My Ideas')]"));

		public IWebElement CreateIdeaLink => _driver.FindElement(By.XPath("//a[contains(text(), 'My Profile')]"));

		public IWebElement LogoutLink => _driver.FindElement(By.XPath("//a[contains(text(), 'Logout')]"));
	}
}
