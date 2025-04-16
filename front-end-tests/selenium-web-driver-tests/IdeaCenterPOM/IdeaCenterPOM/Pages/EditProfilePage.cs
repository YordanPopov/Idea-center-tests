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
			if (ProfilePictureField.GetAttribute("value") != profilPic)
			{
				ProfilePictureField.Clear();
				ProfilePictureField.SendKeys(profilPic);
			}

			if (FirstNameField.GetAttribute("value") != fName)
			{
				FirstNameField.Clear();
				FirstNameField.SendKeys(fName);
			}

			if (LastNameField.GetAttribute("value") != lName)
			{
				LastNameField.Clear();
				LastNameField.SendKeys(lName);
			}

			if (CityField.GetAttribute("value") != city)
			{
				CityField.Clear();
				CityField.SendKeys(city);
			}

			if (DescriptionField.Text != desc)
			{
				DescriptionField.Clear();
				DescriptionField.SendKeys(desc);
			}

			actions.MoveToElement(DoneButton)
				.Click()
				.Perform();
		}
	}
}
