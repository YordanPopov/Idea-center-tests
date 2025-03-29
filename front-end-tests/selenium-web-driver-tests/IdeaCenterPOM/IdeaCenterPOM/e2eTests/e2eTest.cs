using IdeaCenterPOM.Pages;
using IdeaCenterPOM.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.e2eTests
{
	[TestFixture("chrome")]
	[TestFixture("firefox")]
	[TestFixture("edge")]
	public class e2eTest : BaseTest
	{
		private static string lastCreatedIdeaTitle;
		private static string lastCreatedIdeaDescription;

		public e2eTest(string browserType) : base(browserType) { }

		[OneTimeSetUp]
		public void E2E_OneTimeSetUp()
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
			_createIdeaPage.OpenPage();

			string rndStr = GenerateRandomString(10);
			lastCreatedIdeaTitle = $"Name_{rndStr}";
			lastCreatedIdeaDescription = $"Description_{rndStr}";

			_createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);
			Assert.That(_myIdeasPage.IsPageOpened(), Is.True);
			Assert.That(_myIdeasPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(3)]
		public void Test_ViewLastCreatedIdea()
		{
			_myIdeasPage.OpenPage();
			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(lastCreatedIdeaTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));
		}

		[Test, Order(4)]
		public void Test_EditLastCreatedIdeaTitle()
		{
			_myIdeasPage.OpenPage();
			_myIdeasPage.EditButton.Click();

			string editedTitle = $"Changed: {lastCreatedIdeaTitle}";
			_editIdeaPage.TitleField.Clear();
			_editIdeaPage.TitleField.SendKeys(editedTitle);
			_editIdeaPage.EditBtn.Click();

			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(editedTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(lastCreatedIdeaDescription));

			lastCreatedIdeaTitle = editedTitle;
		}

		[Test, Order(5)]
		public void Test_EditLastCreatedIdeaDescription()
		{
			_myIdeasPage.OpenPage();
			_myIdeasPage.EditButton.Click();

			string editedDesc = $"Changed: {lastCreatedIdeaDescription}";
			_editIdeaPage.DescField.Clear();
			_editIdeaPage.DescField.SendKeys(editedDesc);
			_editIdeaPage.EditBtn.Click();

			_myIdeasPage.ViewButton.Click();

			Assert.That(_viewIdeaPage.IdeaTitle.Text, Is.EqualTo(lastCreatedIdeaTitle));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Is.EqualTo(editedDesc));

			lastCreatedIdeaDescription = editedDesc;
		}

		[Test, Order(6)]
		public void Test_DeleteLastCreatedIdeaTest()
		{
			_myIdeasPage.OpenPage();
			Assert.That(_myIdeasPage.Ideas.Count, Is.GreaterThan(0));

			_myIdeasPage.DeleteButton.Click();

			_driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

			bool isIdeaDeleted = _myIdeasPage.Ideas.All(idea => !idea.Text.Contains(lastCreatedIdeaDescription));
			Assert.That(isIdeaDeleted, Is.True);
			//Assert.That(_myIdeasPage.Ideas.Count, Is.EqualTo(0));
		}
	}
}
