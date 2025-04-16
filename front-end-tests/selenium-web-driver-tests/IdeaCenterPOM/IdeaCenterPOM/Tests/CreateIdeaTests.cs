using IdeaCenterPOM.Pages;
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
	public class CreateIdeaTests : BaseTest
	{
		public CreateIdeaTests(string browserType) : base(browserType)
		{

		}

		[OneTimeSetUp]
		public void CreateIdea_OneTimeSetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[SetUp]
		public void CreateIdea_SetUp()
		{
			_createIdeaPage.OpenPage();
		}

		[TearDown]

		public void TearDown()
		{
			if (_myIdeasPage.Ideas.Any())
				_myIdeasPage.DeleteButton.Click();
		}

		[Test]
		public void Test_CreateIdeaWithEmptyFields()
		{
			_createIdeaPage.CreateIdea("", "", "");

			Assert.That(_createIdeaPage.IsPageOpened(), Is.True);
			Assert.That(_createIdeaPage.MainErrorMsg.Text, Does.Contain("Unable to create new Idea!"));
			Assert.That(_createIdeaPage.TitleErrorMsg.Text, Does.Contain("The Title field is required."));
			Assert.That(_createIdeaPage.DescErrorMsg.Text, Does.Contain("The Description field is required."));
		}

		[Test]
		public void Test_CreateIdeaWithValidData()
		{
			string ideaTitle = $"TITLE_{GenerateRandomString(5)}";
			string ideaDesc = $"DESCRIPTION_{GenerateRandomString(5)}";

			_createIdeaPage.CreateIdea(ideaTitle, "", ideaDesc);

			Assert.IsTrue(_myIdeasPage.IsPageOpened());
			Assert.That(_myIdeasPage.IdeaDescription.Text.Trim(), Is.EqualTo(ideaDesc));
		}
	}
}
