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
		public LoginPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Users/Login";

		public IWebElement EmailField => _driver.FindElement(By.Id("typeEmailX-2"));
		public IWebElement PasswordField => _driver.FindElement(By.Id("typePasswordX-2"));
		public IWebElement SignInButton => _driver.FindElement(By.XPath("//button[@type='submit' and @class='btn btn-primary btn-lg btn-block']"));
		public IWebElement GoogleSignInBtn => _driver.FindElement(By.XPath("//button[@type='submit' and @class='btn btn-lg btn-block btn-primary']"));
		public IWebElement FacebookSignInBtn => _driver.FindElement(By.XPath("//button[@type='submit' and @class='btn btn-lg btn-block btn-primary mb-2']"));
		public IWebElement RememberPassCheck => _driver.FindElement(By.Name("RememberMe"));
		public string MainErrorMsg => _driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li")).Text;
		public string EmailErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Email']")).Text;
		public string PasswordErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Password']")).Text;

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
