using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class EditIdeaPage : BasePage
	{
		public EditIdeaPage(IWebDriver driver) : base(driver)
		{
		}

		public IWebElement TitleField => _driver.FindElement(By.Id("form3Example1c"));

		public IWebElement ImgField => _driver.FindElement(By.Id("form3Example3c"));

		public IWebElement DescField => _driver.FindElement(By.Id("form3Example4cd"));

		public IWebElement EditBtn => _driver.FindElement(By.XPath("//button[@type='submit']"));

		public void EditIdea(string newTitle, string imgUrl, string newDescription)
		{
			if (TitleField.Text != newTitle)
			{
				TitleField.Clear();
				TitleField.SendKeys(newTitle);
			}

			if (DescField.Text != newDescription)
			{
				DescField.Clear();
				DescField.SendKeys(newDescription);
			}

			if (ImgField.Text != imgUrl)
			{
				ImgField.Clear();
				ImgField.SendKeys(imgUrl);
			}

			EditBtn.Click();
		}
	}
}
