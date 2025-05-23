﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Pages
{
	public class MyIdeasPage : BasePage
	{
		public MyIdeasPage(IWebDriver driver) : base(driver)
		{
			_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
		}
		public override string PageUrl => base.PageUrl + "/Ideas/MyIdeas";

		public ReadOnlyCollection<IWebElement> Ideas => this._wait.Until(drv => drv.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']")));

		public IWebElement ViewButton => Ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Read')]"));

		public IWebElement EditButton => Ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Edit')]"));

		public IWebElement DeleteButton => Ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Delete')]"));

		public IWebElement IdeaDescription => Ideas.Last().FindElement(By.XPath(".//p[@class='card-text']"));

		public IWebElement SearchField => _driver.FindElement(By.Id("search-input"));

		public IWebElement SearchButton => _driver.FindElement(By.Id("search-button"));

		public IWebElement NoIdeasMessage => _driver.FindElement(By.XPath("//div[@class='row text-center']/span"));
	}
}
