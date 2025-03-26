using IdeaCenterPOM.Pages;
using IdeaCenterPOM.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.e2eTests
{
	[TestFixture]
	public class e2eTest : BaseTest
	{
		private static string lastCreatedIdeaTitle;
		private static string lastCreatedIdeaDescription;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[Test, Order(1)]
		public void Test_CreateIdeaWithInvalidData()
		{
			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea("", "", "");

			Assert.That(_createIdeaPage.IsPageOpened(), Is.True);
			Assert.That(_createIdeaPage.MainErrorMsg.Text, Is.EqualTo("Unable to create new Idea!"));
			Assert.That(_createIdeaPage.TitleErrorMsg.Text, Is.EqualTo("The Title field is required."));
			Assert.That(_createIdeaPage.DescErrorMsg.Text, Is.EqualTo("The Description field is required."));
		}

		[Test, Order(2)]
		public void Test_CreateIdeaWithRandomData()
		{
			_createIdeaPage = new CreateIdeaPage(_driver);
			_createIdeaPage.OpenPage();

			string rndStr = GenerateRandomString(10);
			lastCreatedIdeaTitle = $"Name_{rndStr}";
			lastCreatedIdeaDescription = $"Description_{rndStr}";

			_createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);
			Assert.That(_driver.Url, Does.Contain("/Ideas/MyIdeas"));
			Assert.That(_myIdeasPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(3)]
		public void Test_ViewLastCreatedIdea()
		{
			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.OpenPage();
			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(lastCreatedIdeaTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(4)]
		public void Test_EditLastCreatedIdeaTitle()
		{
			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.OpenPage();
			_myIdeasPage.EditButton.Click();

			string editedTitle = $"Changed Title: {lastCreatedIdeaTitle}";
			_editIdeaPage.TitleField.Clear();
			_editIdeaPage.TitleField.SendKeys(editedTitle);
			_editIdeaPage.EditBtn.Click();

			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(editedTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));

			lastCreatedIdeaTitle = editedTitle;
		}

		[Test, Order(5)]
		public void Test_EditLastCreatedIdeaDescription()
		{
			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.OpenPage();
			_myIdeasPage.EditButton.Click();

			string editedDesc = $"Changed Description: {lastCreatedIdeaDescription}";
			_editIdeaPage.DescField.Clear();
			_editIdeaPage.DescField.SendKeys(editedDesc);
			_editIdeaPage.EditBtn.Click();

			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(lastCreatedIdeaTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(editedDesc));

			lastCreatedIdeaDescription = editedDesc;
		}

		[Test, Order(6)]
		public void Test_DeleteLastCreatedIdeaTest()
		{
			_myIdeasPage = new MyIdeasPage(_driver);
			_myIdeasPage.OpenPage();
			_myIdeasPage.DeleteButton.Click();


			Assert.That(_myIdeasPage.Ideas.Count, Is.EqualTo(0));
		}
	}
}
