using IdeaCenterPOM.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

		protected EditProfilePage _editProfilePage;

		protected MyProfilePage _myProfilePage;

		protected RegisterPage _registerPage;

		private string browserType;

		public BaseTest(string browserType)
		{
			this.browserType = browserType;
		}

		[OneTimeSetUp]
		public void Base_OneTimeSetUp()
		{
			//var options = GetOptions(browserType);

			//java -jar selenium-server-4.28.1.jar standalone
			//_driver = new RemoteWebDriver(new Uri("http://localhost:4444"), options);
			_driver = GetWebDriver(browserType);
			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			_loginPage = new LoginPage(_driver);
			_homePage = new HomePage(_driver);
			_myIdeasPage = new MyIdeasPage(_driver);
			_createIdeaPage = new CreateIdeaPage(_driver);
			_editIdeaPage = new EditIdeaPage(_driver);
			_viewIdeaPage = new ViewIdeaPage(_driver);
			_editProfilePage = new EditProfilePage(_driver);
			_myProfilePage = new MyProfilePage(_driver);
			_registerPage = new RegisterPage(_driver);
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			_driver.Close();
			_driver.Dispose();
		}
		public string GenerateRandomString(int length)
		{
			var rnd = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[rnd.Next(s.Length)]).ToArray());
		}

		//private DriverOptions GetOptions(string browserType)
		//{
		//	if (browserType == "chrome")
		//	{
		//		ChromeOptions chromeOptions = new ChromeOptions();
		//		chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
		//		chromeOptions.AddArgument("--disable-search-engine-choice-screen");
		//		chromeOptions.AddArgument("--start-maximized");
		//		chromeOptions.AddArgument("--disable-infobars");
		//		chromeOptions.AddArgument("--disable-popup-blocking");
		//		chromeOptions.AddArgument("--disable-gpu");

		//		return chromeOptions;
		//	} 
		//	else if (browserType == "firefox")
		//	{
		//		FirefoxOptions firefoxOptions = new FirefoxOptions();
		//		firefoxOptions.AddArgument("--kiosk");

		//		return firefoxOptions;
		//	}
		//	else
		//	{
		//		EdgeOptions edgeOptions = new EdgeOptions();
		//		edgeOptions.AddArgument("--start-maximized");

		//		return edgeOptions;
		//	}
		//}

		private IWebDriver GetWebDriver(string browser)
		{
			switch (browser.ToLower())
			{
				case "chrome":
					var chromeOptions = new ChromeOptions();
					chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
					chromeOptions.AddArgument("--disable-search-engine-choice-screen");
					chromeOptions.AddArgument("--start-maximized");
					chromeOptions.AddArgument("--disable-infobars");
					chromeOptions.AddArgument("--disable-popup-blocking");
					chromeOptions.AddArgument("--disable-gpu");
					return new ChromeDriver(chromeOptions);

				case "firefox":
					var firefoxOptions = new FirefoxOptions();
					firefoxOptions.AddArgument("--kiosk");
					return new FirefoxDriver(firefoxOptions);

				case "edge":
					var edgeOptions = new EdgeOptions();
					edgeOptions.AddArgument("--start-maximized");
					return new EdgeDriver(edgeOptions);

				default:
					throw new ArgumentException($"Unsupported browse: {browser}");
			}
		}
	}
}
