using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class MyProfilePage : BasePage
	{
		public MyProfilePage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Profile";

		public string UserName => _driver.FindElement(By.XPath("//div[@class='ms-3']/h5")).Text;

		public string UserInfo => _driver.FindElement(By.XPath("//div[@class='ms-3']/p")).Text;

		public int UserIdeasCount => int.Parse(_driver.FindElement(By.XPath("//div/p[@class='mb-1 h5']")).Text);

		public string AboutSection => _driver.FindElement(By.XPath("//div[@class='p-4']/p")).Text;

		public IWebElement ShowAllButton => _driver.FindElement(By.XPath("//a[@class='text-muted']"));

		public IWebElement EditProfileButton => _driver.FindElement(By.XPath("//span[@type='button']"));

	}
}
