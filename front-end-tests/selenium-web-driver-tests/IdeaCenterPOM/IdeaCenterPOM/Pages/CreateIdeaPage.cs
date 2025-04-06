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
		public CreateIdeaPage(IWebDriver driver) : base(driver) { }

		public override string PageUrl => base.PageUrl + "/Ideas/Create";
		public IWebElement TitleField => _driver.FindElement(By.XPath("//input[@name='Title']")); // 2 - 70
		public IWebElement ImgUrlField => _driver.FindElement(By.XPath("//input[@name='Url']"));
		public IWebElement DescriptionField => _driver.FindElement(By.XPath("//textarea[@name='Description']")); // 3 - 400
		public IWebElement CreateButton => _driver.FindElement(By.XPath("//button[@type='submit']"));
		public IWebElement MainErrorMsg => _driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
		public IWebElement TitleErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Title']"));
		public IWebElement DescErrorMsg => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Description']"));

		public void CreateIdea(string title, string imgUrl, string desc)
		{
			TitleField.Clear();
			TitleField.SendKeys(title);

			ImgUrlField.Clear();
			ImgUrlField.SendKeys(imgUrl);

			DescriptionField.Clear();
			DescriptionField.SendKeys(desc);

			CreateButton.Click();
		}
	}
}
