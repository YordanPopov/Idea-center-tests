using OpenQA.Selenium;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class LoginPage : BasePage
	{
		public LoginPage(IWebDriver driver) : base(driver)
		{
		}
		public override string PageUrl => base.PageUrl + "/Users/Login";

		public IWebElement EmailField => _driver.FindElement(By.Id("typeEmailX-2"));

		public IWebElement PasswordField => _driver.FindElement(By.Id("typePasswordX-2"));

		public IWebElement SignInButton => _driver.FindElement(By.XPath("//button[text()='Sign in']"));

		public void LoginUser(string email, string password)
		{
			EmailField.Clear();
			PasswordField.Clear();

			EmailField.SendKeys(email);
			PasswordField.SendKeys(password);
			SignInButton.Click();
		}
	}
}
