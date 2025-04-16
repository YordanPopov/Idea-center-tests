using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class ViewIdeaPage : BasePage
	{
		public ViewIdeaPage(IWebDriver driver) : base(driver) { }

		public IWebElement IdeaTitle => _driver.FindElement(By.TagName("h1"));

		public IWebElement IdeaDescription => _driver.FindElement(By.XPath("//section[@class='row']/p"));

		public IWebElement DeleteBtn => _driver.FindElement(By.XPath("//a[contains(@href, 'Delete')]"));

		public IWebElement EditBtn => _driver.FindElement(By.XPath("//a[contains(@href, 'Edit')]"));

		public IWebElement UserProfileLink => _driver.FindElement(By.XPath("//a[@class='text-dark' and contains(@href, 'Profile')]"));
	}
}
