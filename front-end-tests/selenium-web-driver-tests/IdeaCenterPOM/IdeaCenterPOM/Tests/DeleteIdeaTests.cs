using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture("chrome")]
	public class DeleteIdeaTests : BaseTest
	{
		public DeleteIdeaTests(string browserType) : base(browserType) { }

		[SetUp]
		public void DeleteIdea_SetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[Test]
		public void Test_DeleteIdea_AndVerifyNoIdeasMessageIsdDisplayed()
		{
			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea("testIdea1", "", "testDescription");

			Assert.That(_myIdeasPage.IsPageOpened(), Is.True);
			_myIdeasPage.DeleteButton.Click();

			Assert.That(_driver.FindElement(By.XPath("//div[@class='row text-center']/span")).Text, Is.EqualTo("No Ideas yet!"));
		}
	}
}
