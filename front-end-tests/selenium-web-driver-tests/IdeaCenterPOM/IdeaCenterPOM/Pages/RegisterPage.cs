using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class RegisterPage : BasePage
	{
		public RegisterPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Users/Register";

		public IWebElement UserNameField => _driver.FindElement(By.Name("UserName"));
		public IWebElement EmailField => _driver.FindElement(By.Name("Email"));
		public IWebElement PasswordField => _driver.FindElement(By.Name("Password"));
		public IWebElement RePasswordField => _driver.FindElement(By.Name("RePassword"));
		public IWebElement AcceptedAgreement => _driver.FindElement(By.Name("AcceptedAgreement"));
		public IWebElement RegisterButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
		public IWebElement TermsOfServLink => _driver.FindElement(By.XPath("//a[contains(@href, '/Home/Terms')]"));

		public void RegisterUser(string uName, string email, string pass, string rePass, bool isAccepted)
		{
			UserNameField.Clear();
			UserNameField.SendKeys(uName);

			EmailField.Clear();
			EmailField.SendKeys(email);

			PasswordField.Clear();
			PasswordField.SendKeys(pass);

			RePasswordField.Clear();
			RePasswordField.SendKeys(rePass);

			if (isAccepted)
			{
				AcceptedAgreement.Click();
			}

			RegisterButton.Click();
		}
	}
}
