using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class CreateIdeaPage : BasePage
	{
		public CreateIdeaPage(IWebDriver driver) : base(driver)
		{
		}

		public override string PageUrl => base.PageUrl + "/Ideas/Create";

		public IWebElement TitleField => _driver.FindElement(By.Id("form3Example1c"));

		public IWebElement ImgUrlField => _driver.FindElement(By.Id("form3Example3c"));

		public IWebElement DescriptionField => _driver.FindElement(By.Id("form3Example4cd"));

		public IWebElement CreateButton => _driver.FindElement(By.XPath("//button[@type='submit']"));

		public IWebElement MainErrorMsg => _driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
		public IWebElement TitleErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Title']"));

		public IWebElement DescErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Description']"));

		public void CreateIdea(string title, string imgUrl, string desc)
		{
			TitleField.Clear();
			ImgUrlField.Clear();
			DescriptionField.Clear();

			TitleField.SendKeys(title);
			ImgUrlField.SendKeys(imgUrl);
			DescriptionField.SendKeys(desc);
			CreateButton.Click();
		}
	}
}
