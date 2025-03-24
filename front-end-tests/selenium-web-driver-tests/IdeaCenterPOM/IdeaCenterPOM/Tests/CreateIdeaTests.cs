using IdeaCenterPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture]
	public class CreateIdeaTests : BaseTest
	{
		[OneTimeSetUp]
		public void CreateIdeaOneTimeSetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[Test]
		public void Test_CreateIdeaWithEmptyFields()
		{
			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea("", "", "");

			Assert.That(_createIdeaPage.IsPageOpened(), Is.True);
			Assert.That(_createIdeaPage.MainErrorMsg.Text, Does.Contain("Unable to create new Idea!"));
			Assert.That(_createIdeaPage.TitleErrorMsg.Text, Does.Contain("The Title field is required."));
			Assert.That(_createIdeaPage.DescErrorMsg.Text, Does.Contain("The Description field is required."));
		}

		[Test]
		public void Test_CreateIdeaWithValidData()
		{
			var rnd = new Random();
			int randomNum = rnd.Next(1000, 9999);
			string ideaTitle = "testIdea_" + randomNum;
			string ideaDesc = "testDescription_" + randomNum; 

			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea(ideaTitle, "", ideaDesc);

			Assert.That(_myIdeasPage.IsPageOpened(), Is.True);
			Assert.That(_myIdeasPage.IdeaDescription.Text.Trim(), Is.EqualTo(ideaDesc));
		}
	}
}
