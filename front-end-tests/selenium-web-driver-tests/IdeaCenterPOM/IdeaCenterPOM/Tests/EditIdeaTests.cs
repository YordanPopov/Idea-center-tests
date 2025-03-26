using IdeaCenterPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	public class EditIdeaTests : BaseTest
	{
		[OneTimeSetUp]
		public void EditIdea_OneTimeSetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[TearDown]
		public void EditIdea_TearDown()
		{
			_myIdeasPage.DeleteButton.Click();
		}

		[Test]
		public void Test_EditIdeaWithEmptyFields()
		{
			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea("testIdea", "", "testDescription");
			Assert.That(_myIdeasPage.IsPageOpened(), Is.True);
			
			_myIdeasPage.EditButton.Click();
			_editIdeaPage.EditIdea("", "", "");

			Assert.That(_driver.Url, Does.Contain("/Ideas/Edit"));
			Assert.That(_editIdeaPage.MainErrorMsg.Displayed, Is.True);
			Assert.That(_editIdeaPage.MainErrorMsg.Text, Is.EqualTo("Unable to edit the Idea!"));
			Assert.That(_editIdeaPage.TitleErrorMsg.Displayed, Is.True);
			Assert.That(_editIdeaPage.TitleErrorMsg.Text, Is.EqualTo("The Title field is required."));
			Assert.That(_editIdeaPage.DescErrorMsg.Displayed, Is.True);
			Assert.That(_editIdeaPage.DescErrorMsg.Text, Is.EqualTo("The Description field is required."));

			_myIdeasPage.OpenPage();
		}

		[Test]
		public void Test_EditIdeaWithValidData()
		{
			_createIdeaPage.OpenPage();
			_createIdeaPage.CreateIdea("testIdea", "", "testDescription");

			Assert.That(_myIdeasPage.IsPageOpened(), Is.True);

			_myIdeasPage.EditButton.Click();
			_editIdeaPage.EditIdea("editedTestIdea", "", "editedTestDescription");

			_myIdeasPage.ViewButton.Click();
			Assert.That(_viewIdeaPage.IdeaTitle.Text, Does.Contain("edited"));
			Assert.That(_viewIdeaPage.IdeaDescription.Text, Does.Contain("edited"));

			_myIdeasPage.OpenPage();
		}
	}
}
