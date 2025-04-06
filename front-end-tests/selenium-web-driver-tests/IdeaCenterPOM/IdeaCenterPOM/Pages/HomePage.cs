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
		public HomePage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/";

		// Guest user
		public IWebElement LinkLoginPage => _driver.FindElement(By.XPath("//a[@class='nav-link' and @href='/']"));
		public IWebElement LinkRegisterPage => _driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3' and @href='/Users/Register']"));
		public IWebElement LinkHomePage => _driver.FindElement(By.XPath("//a[@class='nav-link' and contains(text(), 'Idea Center')]"));
		public IWebElement Carousel => _driver.FindElement(By.Id("carouselExampleIndicators"));

		// Logged-in user
		public IWebElement MyProfileLink => _driver.FindElement(By.XPath("//a[@class='nav-link' and @href='/Profile']"));
		public IWebElement MyIdeasLink => _driver.FindElement(By.XPath("//a[@class='nav-link' and @href='/Ideas/MyIdeas']"));
		public IWebElement CreateIdeaLink => _driver.FindElement(By.XPath("//a[@class='nav-link' and @href='/Ideas/Create']"));
		public IWebElement LogoutLink => _driver.FindElement(By.XPath("//a[@class='btn btn-primary me-3' and @href='/Users/Logout']"));
	}
}
 