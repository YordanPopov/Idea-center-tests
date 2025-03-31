using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class EditProfilePage : BasePage
	{
		public EditProfilePage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Profile/Edit";

		public IWebElement ProfilePictureField => _driver.FindElement(By.Name("ProfilePicture"));

		public IWebElement FirstNameField => _driver.FindElement(By.Name("FirstName"));

		public IWebElement LastNameField => _driver.FindElement(By.Name("LastName"));

		public IWebElement CityField => _driver.FindElement(By.Name("City"));

		public IWebElement DescriptionField => _driver.FindElement(By.Name("About"));

		public IWebElement DoneButton => _driver.FindElement(By.XPath("//button[@type='submit']"));


		public void EditProfile(string profilPic, string fName, string lName, string city, string desc)
		{
			ProfilePictureField.Clear();
			ProfilePictureField.SendKeys(profilPic);

			FirstNameField.Clear();
			FirstNameField.SendKeys(fName);

			LastNameField.Clear();
			LastNameField.SendKeys(lName);

			CityField.Clear();
			CityField.SendKeys(city);

			DescriptionField.Clear();
			DescriptionField.SendKeys(desc);

			DoneButton.Click();
		}
	}
}
