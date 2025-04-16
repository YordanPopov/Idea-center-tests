using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture("chrome")]
	[TestFixture("firefox")]
	[TestFixture("edge")]
	public class DeleteIdeaTests : BaseTest
	{
		public DeleteIdeaTests(string browserType) : base(browserType)
		{

		}

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

			string ideaTitle = $"TITLE{GenerateRandomString(5)}";
			string ideaDescription = $"DESCRIPTION{GenerateRandomString(5)}";
			_createIdeaPage.CreateIdea(ideaTitle, "", ideaDescription);

			Assert.IsTrue(_myIdeasPage.IsPageOpened());
			_myIdeasPage.DeleteButton.Click();

			Assert.That(_myIdeasPage.NoIdeasMessage.Text.Trim(), Is.EqualTo("No Ideas yet!"));
		}
	}
}
