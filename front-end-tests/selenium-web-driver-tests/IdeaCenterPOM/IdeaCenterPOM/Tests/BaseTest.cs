using IdeaCenterPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	public class BaseTest
	{
		protected IWebDriver _driver;
		protected HomePage _homePage;
		protected LoginPage _loginPage;
		protected CreateIdeaPage _createIdeaPage;
		protected MyIdeasPage _myIdeasPage;
		protected EditIdeaPage _editIdeaPage;
		protected ViewIdeaPage _viewIdeaPage;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			var chromeOptions = new ChromeOptions();
			chromeOptions.AddUserProfilePreference("profile.password_manager_ebabled", false);
			chromeOptions.AddArgument("--disable-search-engine-choice-screen");

			_driver = new ChromeDriver(chromeOptions);
			_driver.Manage().Window.Maximize();
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			_loginPage = new LoginPage(_driver);
			_homePage = new HomePage(_driver);
			_myIdeasPage = new MyIdeasPage(_driver);
			_createIdeaPage = new CreateIdeaPage(_driver);
			_editIdeaPage = new EditIdeaPage(_driver);
			_viewIdeaPage = new ViewIdeaPage(_driver);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			_driver.Quit();
			_driver.Dispose();
		}

		public string GenerateRandomString(int lenght)
		{
			var rnd = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, lenght)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}
	}
}
