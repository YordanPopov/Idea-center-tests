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

		public IWebElement MainErrorMsg => _driver.FindElement(By.XPath("//div[contains(@class, 'text-danger')]/ul/li"));

		public IWebElement TitleErrorMsg => _driver.FindElement(By.XPath("//span[contains(@data-valmsg-for, 'Title')]"));

		public IWebElement DescErrorMsg => _driver.FindElement(By.XPath("//span[contains(@data-valmsg-for, 'Description')]"));

		public void EditIdea(string newTitle, string imgUrl, string newDescription)
		{
			string currentTitle = TitleField.GetAttribute("value");
			string currentImgUrl = ImgField.GetAttribute("value");

			if (currentTitle != newTitle)
			{
				TitleField.Clear();
				TitleField.SendKeys(newTitle);
			}

			if (currentImgUrl != imgUrl)
			{
				ImgField.Clear();
				ImgField.SendKeys(imgUrl);
			}

			if (DescField.Text != newDescription)
			{
				DescField.Clear();
				DescField.SendKeys(newDescription);
			}
			EditBtn.Click();
		}
	}
}
